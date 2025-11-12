using System.Collections;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static int HealthMultiplier { get; private set; } = 1; // Global health multiplier
    [SerializeField] private int healthIncreaseAmount = 10; // Base health increment per interval
    [SerializeField] private float interval = 10f; // Time interval in seconds

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
        }
    }

    public static int GetBaseHealth()
    {
        return HealthMultiplier * 10; // Base health is 10, scaled by multiplier
    }
}