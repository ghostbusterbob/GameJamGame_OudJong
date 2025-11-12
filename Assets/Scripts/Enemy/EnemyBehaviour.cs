using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            spawner.DespawnEnemyFromBehavior(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            spawner.DespawnEnemyFromBehavior(gameObject);
        }
    }
}