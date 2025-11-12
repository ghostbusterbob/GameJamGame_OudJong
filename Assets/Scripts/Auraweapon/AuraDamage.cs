using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class AuraDamage : MonoBehaviour
{
    [Header("Damage Over Time")]
    [SerializeField] private int damagePerSecond = 10;   // e.g., 10 DPS
    [SerializeField] private float tickInterval = 0.2f;  // apply damage every 0.2s

    // Throttle per enemy so we don't damage every physics step
    private readonly Dictionary<EnemyBehavior, float> nextTickAt = new Dictionary<EnemyBehavior, float>();

    private void Awake()
    {
        // Ensure trigger collider
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Find the enemy component (supports colliders on children)
        EnemyBehavior enemy = other.GetComponentInParent<EnemyBehavior>() ?? other.GetComponent<EnemyBehavior>();
        if (enemy == null || !enemy.isActiveAndEnabled) return;

        float now = Time.time;
        if (!nextTickAt.TryGetValue(enemy, out float allowedAt) || now >= allowedAt)
        {
            int dmg = Mathf.Max(1, Mathf.RoundToInt(damagePerSecond * tickInterval));
            enemy.TakeDamage(dmg);
            nextTickAt[enemy] = now + tickInterval;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponentInParent<EnemyBehavior>() ?? other.GetComponent<EnemyBehavior>();
        if (enemy != null) nextTickAt.Remove(enemy);
    }

    private void OnDisable()
    {
        // Safety: clear cache when aura gets disabled
        nextTickAt.Clear();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var circle = GetComponent<CircleCollider2D>();
        if (circle != null)
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(circle.offset, circle.radius);
        }
    }
#endif
}