using System.Collections;
using UnityEngine;

public class PizzaFrisbeeLauncher: MonoBehaviour
{
    [SerializeField] private PizzaFrisbee frisbeePrefab;
    [SerializeField] private float respawnDelay = 5f;

    private void Start()
    {
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            Instantiate(frisbeePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(respawnDelay);
        }
    }
}