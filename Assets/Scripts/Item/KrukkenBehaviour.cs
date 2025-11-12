using UnityEngine;

public class KrukkenBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyBehavior component
            EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                // Deal damage to the enemy
                enemy.TakeDamage(10); // Adjust the damage value as needed
            }

            // Destroy the Krukken after hitting an enemy
            Destroy(gameObject);
        }
    }
}