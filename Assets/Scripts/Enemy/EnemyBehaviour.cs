using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySpawner spawner;
    [SerializeField] private GameObject xpPrefab; // Reference to the XP item prefab

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            DropXP(); // Drop XP item
            spawner.DespawnEnemyFromBehavior(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            spawner.DespawnEnemyFromBehavior(gameObject);
        }
    }

    private void DropXP()
    {
        if (xpPrefab != null)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
        }
    }
}