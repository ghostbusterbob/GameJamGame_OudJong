using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; private set; } = 1; // Player's current level
    private int currentXP = 0; // Current XP collected
    private int xpToNextLevel = 10; // XP required for the next level

    [Header("Weapons and Prefabs")]
    public MonoBehaviour[] weaponScripts; // List of weapon scripts (e.g., PlayerShooting, PlayerAttack, WeaponLauncher)
    public GameObject auraPrefab; // Aura prefab to activate

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log($"XP Collected: {currentXP}/{xpToNextLevel}");

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        currentXP -= xpToNextLevel; // Carry over extra XP
        xpToNextLevel += Mathf.CeilToInt(xpToNextLevel * 0.5f); // Increase XP requirement by 50%
        Debug.Log($"Player leveled up! Current Level: {Level}, XP to next level: {xpToNextLevel}");

        ActivateRandomWeaponOrPrefab();
    }

    private void ActivateRandomWeaponOrPrefab()
    {
        // Randomly choose between weapon scripts or the aura prefab
        int randomIndex = Random.Range(0, weaponScripts.Length + 1);

        if (randomIndex < weaponScripts.Length)
        {
            // Activate a random weapon script
            weaponScripts[randomIndex].enabled = true;
            Debug.Log($"Activated weapon script: {weaponScripts[randomIndex].GetType().Name}");
        }
        else
        {
            // Activate the aura prefab
            if (auraPrefab != null)
            {
                auraPrefab.SetActive(true);
                Debug.Log("Activated Aura prefab");
            }
        }
    }
}