using System.Collections;
using UnityEngine;

public class LosPollosHermanos : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject losPollosHermanosPrefab; // Prefab to spawn
    [SerializeField] private Transform spawnPoint; // Spawn location
    [SerializeField] private GameObject xpPrefab; // XP prefab to spawn when enemies are destroyed
    [SerializeField] private float activeDuration = 2f; // Time the prefab stays active
    [SerializeField] private float cooldownDuration = 30f; // Cooldown before it can spawn again

    private bool isOnCooldown = false;

    private void Start()
    {
        StartCoroutine(SpawnAndCooldownRoutine());
    }

    private IEnumerator SpawnAndCooldownRoutine()
    {
        while (true)
        {
            if (!isOnCooldown)
            {
                // Spawn the Los Pollos Hermanos prefab
                if (losPollosHermanosPrefab != null && spawnPoint != null)
                {
                    var instance = Instantiate(losPollosHermanosPrefab, spawnPoint.position, spawnPoint.rotation);
                    DestroyAllEnemies();

                    // Destroy the prefab after the active duration
                    Destroy(instance, activeDuration);
                }

                // Start cooldown
                isOnCooldown = true;
                yield return new WaitForSeconds(activeDuration + cooldownDuration);
                isOnCooldown = false;
            }

            yield return null;
        }
    }

    private void DestroyAllEnemies()
    {
        var enemies = FindObjectsOfType<EnemyBehavior>();
        foreach (var enemy in enemies)
        {
            // Spawn XP prefab at the enemy's position
            if (xpPrefab != null)
            {
                Instantiate(xpPrefab, enemy.transform.position, Quaternion.identity);
            }

            // Destroy the enemy
            Destroy(enemy.gameObject);
        }
    }
}