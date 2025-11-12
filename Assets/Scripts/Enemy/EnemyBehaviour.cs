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

    public void IncreaseHealth(int amount)
    {
        EnemyHealth += amount;
        Debug.Log($"{gameObject.name} health increased to {EnemyHealth}");
    }
    
    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;

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

    private void DropXP()
    {
        if (xpPrefab != null)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
        }
    }
}