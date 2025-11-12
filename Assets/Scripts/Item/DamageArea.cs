using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Damage dealt to enemies
    [SerializeField] private float lifetime = 2f; // Lifetime of the damaging area

    private void Start()
    {
        // Destroy the damaging area after its lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Access the EnemyBehavior script
            EnemyBehavior enemyBehavior = collision.GetComponent<EnemyBehavior>();
            if (enemyBehavior != null)
            {
                enemyBehavior.TakeDamage(damage); // Deal damage to the enemy
            }
        }
    }
}