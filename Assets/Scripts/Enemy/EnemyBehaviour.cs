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

        // Subscribe to the health multiplier update event
        EnemyHealthManager.OnHealthMultiplierUpdated += UpdateHealth;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        EnemyHealthManager.OnHealthMultiplierUpdated -= UpdateHealth;
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

    private void UpdateHealth()
    {
        // Update the enemy's health based on the new multiplier
        int newHealth = EnemyHealthManager.GetBaseHealth();
        if (newHealth > EnemyHealth)
        {
            EnemyHealth = newHealth;
            Debug.Log($"{gameObject.name} health updated to {EnemyHealth}");
        }
    }
}