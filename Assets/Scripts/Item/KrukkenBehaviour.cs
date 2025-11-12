using UnityEngine;

public class KrukkenBehaviour : MonoBehaviour
{
    [SerializeField] private int damage = 10; // Adjustable damage value

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}