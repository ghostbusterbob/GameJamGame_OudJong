using System;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AuraDamageSimple : MonoBehaviour
{
    [Header("Simple ON/OFF")]
    public bool isOn = true;          // flip this to enable/disable the aura

    [Header("Damage (while ON)")]
    public int damagePerTick = 2;
    public float tickInterval = 0.25f;

    [Header("Optional auto-pulse")]
    public bool autoPulse = false;
    public float onDuration = 1.5f;
    public float offDuration = 1.5f;

    private float nextTickTime = 0f;
    private float pulseTimer = 0f;
    private bool pulseState = false;

    private void Awake()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true; // aura is a trigger

        pulseState = isOn;
        pulseTimer = pulseState ? onDuration : offDuration;
    }

    private void Update()
    {
        if (!autoPulse) return;

        pulseTimer -= Time.deltaTime;
        if (pulseTimer <= 0f)
        {
            pulseState = !pulseState;
            isOn = pulseState;
            pulseTimer = pulseState ? onDuration : offDuration;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isOn) return;
        if (Time.time < nextTickTime) return;

        // Look for ANY component up the hierarchy that has TakeDamage(int)
        var behaviours = other.GetComponentsInParent<MonoBehaviour>(true);
        foreach (var b in behaviours)
        {
            if (b == null) continue;
            MethodInfo m = b.GetType().GetMethod("TakeDamage", new Type[] { typeof(int) });
            if (m != null)
            {
                m.Invoke(b, new object[] { damagePerTick });
                break; // stop after first match
            }
        }

        nextTickTime = Time.time + tickInterval;
    }
}