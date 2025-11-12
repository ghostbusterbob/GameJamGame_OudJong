using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorders : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player object
    [SerializeField] private Transform childSprite; // Reference to the child sprite object
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Get the SpriteRenderer component of the child sprite
        spriteRenderer = childSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get the player's current position
        Vector3 playerPosition = player.position;

        // Get the camera's boundaries
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 screenMinBounds = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

        // Calculate the sprite's bounds in world space
        float spriteWidth = spriteRenderer.bounds.size.x / 2;
        float spriteHeight = spriteRenderer.bounds.size.y / 2;

        // Clamp the player's position based on the sprite's edges
        playerPosition.x = Mathf.Clamp(playerPosition.x, screenMinBounds.x + spriteWidth, screenBounds.x - spriteWidth);
        playerPosition.y = Mathf.Clamp(playerPosition.y, screenMinBounds.y + spriteHeight, screenBounds.y - spriteHeight);

        player.position = playerPosition;
    }
}