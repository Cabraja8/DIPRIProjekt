using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 // Provjerite da li koristite Universal Render Pipeline

public class DayTriggerScript : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D globalLight; // Referenca na global light komponentu
    public float targetIntensity = 1.0f; // Ciljani intenzitet
    public float duration = 2.0f; // Trajanje tranzicije u sekundama

    // Start is called before the first frame update
    void Start()
    {
        if (globalLight == null)
        {
            Debug.LogError("Global Light reference is missing.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(IncreaseLightIntensity());
        }
    }

    private IEnumerator IncreaseLightIntensity()
    {
        float startIntensity = globalLight.intensity;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            globalLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        globalLight.intensity = targetIntensity;
    }
}
