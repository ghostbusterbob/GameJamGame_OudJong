using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; private set; } = 1; // Player's current level
    private int currentXP = 0; // Current XP collected
    private int xpToNextLevel = 10; // XP required for the next level
    
    UIManager uiManager;    

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();    
    }

    [Header("Weapons and Prefabs")]
    public MonoBehaviour[] weaponScripts; // List of weapon scripts (e.g., PlayerShooting, PlayerAttack, WeaponLauncher)
    public GameObject auraPrefab; // Aura prefab to activate

    public void AddXP(int amount)
    {
        currentXP += amount;
        uiManager.UpdateSlider(xpToNextLevel);
        uiManager.AddXpToSlider(amount);

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
        uiManager.UpdateSlider(xpToNextLevel);
        ActivateRandomWeaponOrPrefab();
    }

    private void ActivateRandomWeaponOrPrefab()
    {
        // Filter the list to include only disabled weapon scripts
        var inactiveWeapons = new System.Collections.Generic.List<MonoBehaviour>();
        foreach (var weapon in weaponScripts)
        {
            if (!weapon.enabled)
            {
                inactiveWeapons.Add(weapon);
            }
        }

        if (inactiveWeapons.Count > 0)
        {
            // Randomly activate one of the inactive weapon scripts
            int randomIndex = UnityEngine.Random.Range(0, inactiveWeapons.Count);
            inactiveWeapons[randomIndex].enabled = true;
            Debug.Log($"Activated weapon script: {inactiveWeapons[randomIndex].GetType().Name}");
        }
        else
        {
            // If all weapon scripts are already active, activate the aura prefab
            if (auraPrefab != null)
            {
                auraPrefab.SetActive(true);
                Debug.Log("Activated Aura prefab");
            }
        }
    }
}