using UnityEngine;

public class AuraFollower : MonoBehaviour
{
    [Header("Aura Settings")]
    [SerializeField] private GameObject auraPrefab; // Assign your AuraPrefab in the Inspector
    private GameObject auraInstance;

    private void Start()
    {
        if (auraPrefab == null)
        {
            Debug.LogError("AuraPrefab is not assigned!");
            return;
        }

        // Spawn the aura at the player's position
        auraInstance = Instantiate(auraPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (auraInstance != null)
        {
            // Make the aura follow the player
            auraInstance.transform.position = transform.position;
        }
    }

    private void OnDestroy()
    {
        // Destroy the aura when the player is destroyed
        if (auraInstance != null)
        {
            Destroy(auraInstance);
        }
    }
}