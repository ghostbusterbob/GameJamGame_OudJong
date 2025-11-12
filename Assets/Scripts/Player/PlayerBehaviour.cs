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


    void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health > 0)
        {
            TakeDamage(10);
        }
        else if (health < 0)
        {
            die();
        }
    }

    void die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

    }
}