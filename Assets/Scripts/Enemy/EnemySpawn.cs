using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies = 20;
    [SerializeField] private float despawnRadius = 10f;

    [Header("Health Scaling (spawn-time only)")]
    [SerializeField] private int baseHealth = 10;
    [SerializeField] private int healthIncreasePerInterval = 10;
    [SerializeField] private float healthIncreaseIntervalSeconds = 30f;

    private Camera mainCamera;
    private Transform player;

    private readonly List<GameObject> activeEnemies = new List<GameObject>();
    private readonly Queue<GameObject> enemyPool = new Queue<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Prewarm pool
        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }

        // Fill to max at start
        while (activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    private void Update()
    {
        // Despawn by distance
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            var e = activeEnemies[i];
            if (e == null)
            {
                activeEnemies.RemoveAt(i);
                continue;
            }

            if (Vector2.Distance(e.transform.position, player.position) > despawnRadius)
            {
                DespawnEnemy(e);
                activeEnemies.RemoveAt(i);
            }
        }

        // Keep population at max
        while (activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random screen edge
        int edge = Random.Range(0, 4);
        Vector3 viewportPosition = Vector3.zero;
        float spawnOffset = 0.1f;

        switch (edge)
        {
            case 0: // Top
                viewportPosition = new Vector3(Random.Range(0f, 1f), 1f + spawnOffset, 0f);
                break;
            case 1: // Bottom
                viewportPosition = new Vector3(Random.Range(0f, 1f), 0f - spawnOffset, 0f);
                break;
            case 2: // Left
                viewportPosition = new Vector3(0f - spawnOffset, Random.Range(0f, 1f), 0f);
                break;
            case 3: // Right
                viewportPosition = new Vector3(1f + spawnOffset, Random.Range(0f, 1f), 0f);
                break;
        }

        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);
        worldPosition.z = 0f;

        SpawnEnemy(worldPosition);
    }

    public void SpawnEnemy(Vector3 position)
    {
        GameObject enemy = enemyPool.Count > 0 ? enemyPool.Dequeue() : Instantiate(enemyPrefab);

        enemy.transform.SetPositionAndRotation(position, Quaternion.identity);
        enemy.SetActive(true);

        var enemyBehavior = enemy.GetComponent<EnemyBehavior>();
        if (enemyBehavior != null)
        {
            // Compute spawn-time health based on elapsed time
            int increments = Mathf.FloorToInt(Time.timeSinceLevelLoad / healthIncreaseIntervalSeconds);
            int spawnHealth = baseHealth + (increments * healthIncreasePerInterval);

            enemyBehavior.ResetForSpawn(spawnHealth);
        }

        activeEnemies.Add(enemy);
    }

    private void DespawnEnemy(GameObject enemy)
    {
        if (enemy == null) return;

        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }

    // Called by enemy on death
    public void DespawnEnemyFromBehavior(GameObject enemy)
    {
        if (enemy == null) return;

        int idx = activeEnemies.IndexOf(enemy);
        if (idx >= 0) activeEnemies.RemoveAt(idx);

        DespawnEnemy(enemy);
    }
}