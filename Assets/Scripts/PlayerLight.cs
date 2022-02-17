using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    Light2D playerLight;
    float originalRange;

    private void Awake()
    {
        playerLight = GetComponent<Light2D>();
        originalRange = playerLight.pointLightOuterRadius;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Firefly"))
        {
            AddLight();
            Debug.Log("Light added because of firefly");
        }
    }

    private void AddLight()
    {
        originalRange += 1f;
        playerLight.pointLightOuterRadius = originalRange;
    }
}
