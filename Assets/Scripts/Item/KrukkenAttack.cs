using UnityEngine;

public class KrukkenAttack : MonoBehaviour
{
    [SerializeField] private GameObject krukkenPrefab; // Krukken prefab
    [SerializeField] private float duration = 0.5f; // Time before the Krukken disappears

    public void SpawnKrukken(Transform playerTransform)
    {
        // Instantiate the Krukken at the player's position
        GameObject krukken = Instantiate(krukkenPrefab, playerTransform.position, Quaternion.identity);

        // Set the Krukken as a child of the player
        krukken.transform.SetParent(playerTransform);

        // Destroy the Krukken after the specified duration
        Destroy(krukken, duration);
    }
}