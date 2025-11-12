using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 7f; // Movement speed
    [SerializeField] private string horizontalAxis = "Horizontal"; // Input axis for horizontal movement
    [SerializeField] private string verticalAxis = "Vertical"; // Input axis for vertical movement

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