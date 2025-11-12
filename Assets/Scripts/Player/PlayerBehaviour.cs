using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] public float speed = 7f; // Movement speed

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD keys
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrow keys

        // Create a movement vector
        Vector3 movement = new Vector3(horizontal,vertical ,0 );

        // Move the GameObject
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}