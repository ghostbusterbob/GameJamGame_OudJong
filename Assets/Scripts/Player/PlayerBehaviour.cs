using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int health = 100; // Player health
    [SerializeField] public float speed = 7f; // Movement speed
    [SerializeField] public string horizontalAxis = "Horizontal"; // Input axis for horizontal movement
    [SerializeField] public string verticalAxis = "Vertical"; // Input axis for vertical movement

    void Update()
    {
        // Get input from the assigned axes
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);

        // Create a movement vector
        Vector3 movement = new Vector3(horizontal, vertical, 0);

        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered by: {collision.gameObject.name}");

        if (collision.CompareTag("Enemy")) // Check if the collider is an enemy
        {
            TakeDamage(2); // Adjust the damage value as needed
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Clamp health to prevent it from going below 0
        health = Mathf.Max(health, 0);

        Debug.Log($"Player took {damage} damage. Remaining health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}