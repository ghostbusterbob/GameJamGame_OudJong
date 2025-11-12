using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies = 20;
    [SerializeField] private float despawnRadius = 10f;

    private Camera mainCamera;
    private Transform player;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }

        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void Update()
    {
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i] == null || Vector2.Distance(activeEnemies[i].transform.position, player.position) > despawnRadius)
            {
                DespawnEnemy(activeEnemies[i]);
                activeEnemies.RemoveAt(i);
            }
        }

        while (activeEnemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int edge = Random.Range(0, 4);
        Vector3 viewportPosition = Vector3.zero;
        float spawnOffset = 0.1f;

        switch (edge)
        {
            case 0:
                viewportPosition = new Vector3(Random.Range(0f, 1f), 1f + spawnOffset, 0f);
                break;
            case 1:
                viewportPosition = new Vector3(Random.Range(0f, 1f), 0f - spawnOffset, 0f);
                break;
            case 2:
                viewportPosition = new Vector3(0f - spawnOffset, Random.Range(0f, 1f), 0f);
                break;
            case 3:
                viewportPosition = new Vector3(1f + spawnOffset, Random.Range(0f, 1f), 0f);
                break;
        }

        Vector3 worldPosition = mainCamera.ViewportToWorldPoint(viewportPosition);
        worldPosition.z = 0;

        GameObject newEnemy = GetEnemyFromPool(worldPosition);
        activeEnemies.Add(newEnemy);
    }

    private GameObject GetEnemyFromPool(Vector3 position)
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.transform.position = position;
            enemy.SetActive(true);
            return enemy;
        }
        return Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    private void DespawnEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }
    
    public void DespawnEnemyFromBehavior(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }
        DespawnEnemy(enemy);
    }
}