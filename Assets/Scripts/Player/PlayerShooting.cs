using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Bullet prefab
    [SerializeField] private float shootInterval = 0.5f; // Time between shots
    [SerializeField] private Transform shootPoint; // Point where bullets are spawned
    [SerializeField] private float targetRange = 10f; // Range to find enemies

    private void Start()
    {
        // Start shooting automatically
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            // Find the nearest enemy
            GameObject enemy = FindNearestEnemy();
            if (enemy != null)
            {
                // Instantiate the bullet at the shoot point
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
                if (bulletBehavior != null)
                {
                    // Set the target position to the enemy's current position
                    bulletBehavior.SetTarget(enemy.transform.position);
                }
            }

            yield return new WaitForSeconds(shootInterval); // Wait for the next shot
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all enemies
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= targetRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}