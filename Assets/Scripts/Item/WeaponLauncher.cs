using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab
    [SerializeField] private float spawnHeight = 10f; // Height above the player to spawn projectiles
    [SerializeField] private float spawnRadius = 5f; // Radius around the player where projectiles land
    [SerializeField] private float spawnInterval = 1f; // Time between projectile spawns

    private void Start()
    {
        // Start spawning projectiles
        InvokeRepeating(nameof(SpawnProjectile), 0f, spawnInterval);
    }

    private void SpawnProjectile()
    {
        // Randomize the landing position around the player
        Vector3 landingPosition = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;

        // Calculate the spawn position above the player
        Vector3 spawnPosition = new Vector3(landingPosition.x, landingPosition.y + spawnHeight, landingPosition.z);

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Pass the landing position to the projectile
        projectile.GetComponent<Projectile>().SetLandingPosition(landingPosition);
    }
}