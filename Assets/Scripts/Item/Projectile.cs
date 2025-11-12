using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject damageAreaPrefab; // The damaging area prefab
    [SerializeField] private float fallSpeed = 10f; // Speed at which the projectile falls

    private Vector3 landingPosition;

    public void SetLandingPosition(Vector3 position)
    {
        landingPosition = position;
    }

    private void Update()
    {
        // Move the projectile towards the landing position
        transform.position = Vector3.MoveTowards(transform.position, landingPosition, fallSpeed * Time.deltaTime);

        // Check if the projectile has reached the landing position
        if (Vector3.Distance(transform.position, landingPosition) < 0.1f)
        {
            // Spawn the damaging area
            Instantiate(damageAreaPrefab, landingPosition, Quaternion.identity);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}