using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int Level { get; private set; } = 1; // Player's current level
    private int currentXP = 0; // Current XP collected
    private int xpToNextLevel = 10; // XP required for the next level

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
    }
}