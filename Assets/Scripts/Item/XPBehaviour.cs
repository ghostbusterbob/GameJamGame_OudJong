using System;
using UnityEngine;

public class XPBehaviour : MonoBehaviour
{
    [SerializeField] private int xpAmount = 1; // Amount of XP this item gives
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            PlayerLevel playerLevel = collision.GetComponent<PlayerLevel>();
            if (playerLevel != null)
            {
                playerLevel.AddXP(xpAmount);
                Destroy(gameObject); 
            }
        }
    }
}