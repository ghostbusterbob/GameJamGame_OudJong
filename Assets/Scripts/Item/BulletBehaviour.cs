using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Bullet movement speed
    private Camera mainCamera;

    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

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