using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySpawner spawner;
    [SerializeField] private GameObject xpPrefab;
    public int EnemyHealth = 10;
    public bool methflask = false;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage(int damage)
    {
        if (!methflask)
        {
            EnemyHealth -= damage;
            Debug.Log("no methflask damage");
        }
        else
        {
            EnemyHealth -= damage * 2; // Optional: adjust for methflask
            Debug.Log("methflask damage");
        }

        if (EnemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        DropXP();
        spawner.DespawnEnemyFromBehavior(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
