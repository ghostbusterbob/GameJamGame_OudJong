using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class AuraOnOff : MonoBehaviour
{
    [Header("Pulse Timing (seconds)")]
    public float onDuration = 1.5f;
    public float offDuration = 1.5f;
    public bool startOn = true;

    [Header("What to toggle")]
    public MonoBehaviour damageScript; // Assign your AuraDamage script here
    public Collider2D auraCollider;    // Leave empty to auto-grab from this object

    private bool isOn;
    private WaitForSeconds waitOn;
    private WaitForSeconds waitOff;
    private Coroutine loop;

    // Auto-fill helpful defaults when you add the script
    private void Reset()
    {
        auraCollider = GetComponent<Collider2D>();
        if (auraCollider != null) auraCollider.isTrigger = true;

        foreach (var mb in GetComponents<MonoBehaviour>())
        {
            if (mb != null && mb.GetType().Name.Contains("AuraDamage"))
            {
                damageScript = mb;
                break;
            }
        }
    }

    private void Awake()
    {
        if (!auraCollider) auraCollider = GetComponent<Collider2D>();
        if (auraCollider) auraCollider.isTrigger = true;

        waitOn  = new WaitForSeconds(Mathf.Max(0f, onDuration));
        waitOff = new WaitForSeconds(Mathf.Max(0f, offDuration));
    }

    private void OnEnable()
    {
        isOn = startOn;
        Apply(isOn);
        loop = StartCoroutine(Loop());
    }

    private void OnDisable()
    {
        if (loop != null) StopCoroutine(loop);
        Apply(false);
    }

    private System.Collections.IEnumerator Loop()
    {
        while (true)
        {
            yield return isOn ? waitOn : waitOff;
            isOn = !isOn;
            Apply(isOn);
        }
    }

    private void Apply(bool state)
    {
        if (auraCollider) auraCollider.enabled = state;
        if (damageScript) damageScript.enabled = state;
    }
}