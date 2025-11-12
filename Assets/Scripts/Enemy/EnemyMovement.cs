using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Movement speed
    private Transform player; // Reference to the player's transform

    private void Start()
    {
        // Find the player by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        
    }
}