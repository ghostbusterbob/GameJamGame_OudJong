using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Bullet prefab
    [SerializeField] private float shootInterval = 0.5f; // Time between shots
    [SerializeField] private Transform shootPoint; // Point where bullets are spawned

    private void Start()
    {
        // Start shooting automatically
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            // Instantiate the bullet at the shoot point
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            yield return new WaitForSeconds(shootInterval); // Wait for the next shot
        }
    }
}