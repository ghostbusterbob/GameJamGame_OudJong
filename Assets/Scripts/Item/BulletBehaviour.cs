using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Bullet movement speed
    private Vector3 direction; // Direction to move the bullet
    private Camera mainCamera;

    public void SetTarget(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        direction = (targetPosition - transform.position).normalized;
    }

    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Move the bullet in the calculated direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Check if the bullet is out of the camera's view
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet if it hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }
}