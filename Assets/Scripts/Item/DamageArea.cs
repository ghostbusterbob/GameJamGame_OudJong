using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private int damage = 2; // Damage dealt to enemies
    [SerializeField] private float lifetime = 2f; // Lifetime of the damaging area

    private void Start()
    {
        // Destroy the damaging area after its lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy tag detected: " + collision.name);
            EnemyBehavior enemyBehavior = collision.GetComponent<EnemyBehavior>();
            if (enemyBehavior != null)
            {
                Debug.Log("EnemyBehavior found, applying damage.");
                enemyBehavior.TakeDamage(damage); // Deal damage to the enemy
            }
            else
            {
                Debug.LogWarning("EnemyBehavior component not found on: " + collision.name);
            }
        }
    }
}