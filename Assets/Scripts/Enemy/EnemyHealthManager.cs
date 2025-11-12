using System;
using System.Collections;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static int HealthMultiplier { get; private set; } = 1; // Global health multiplier
    [SerializeField] private int healthIncreaseAmount = 10; // Base health increment per interval
    [SerializeField] private float interval = 10f; // Time interval in seconds

    public static event Action OnHealthMultiplierUpdated; // Event to notify enemies

    private void Start()
    {
        StartCoroutine(UpdateHealthMultiplierOverTime());
    }

    private IEnumerator UpdateHealthMultiplierOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            HealthMultiplier++;
            Debug.Log($"Updated global health multiplier to {HealthMultiplier}");

            // Notify all listeners about the update
            OnHealthMultiplierUpdated?.Invoke();
        }
    }

    public static int GetBaseHealth()
    {
        return HealthMultiplier * 10; // Base health is 10, scaled by multiplier
    }
}