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
}