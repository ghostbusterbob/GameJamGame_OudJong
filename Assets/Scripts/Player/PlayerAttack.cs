using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KrukkenAttack krukkenAttack;
    [SerializeField] private float attackInterval = 5f; // Time between automatic attacks

    private void Start()
    {
        // Start the automatic Krukken attack
        StartCoroutine(AutoKrukkenAttack());
    }

    private IEnumerator AutoKrukkenAttack()
    {
        while (true)
        {
            // Spawn the Krukken at the player's position
            krukkenAttack.SpawnKrukken(transform);

            // Wait for the next attack
            yield return new WaitForSeconds(attackInterval);
        }
    }
}