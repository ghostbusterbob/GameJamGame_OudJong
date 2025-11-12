using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Bullet movement speed
    private Vector3 direction; // Direction to move the bullet
    private Camera mainCamera;

    public int damage = 2; // Set how much damage this bullet deals

    public void SetTarget(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        direction = (targetPosition - transform.position).normalized;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Move the bullet
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Destroy if out of screen
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = collision.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Apply damage instead of destroying
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
