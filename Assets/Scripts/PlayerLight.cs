using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PlayerLight : MonoBehaviour
{
    Light2D playerLight;
    float originalRange;

    #region Firefly_counter
    float currFirefly;
    public Slider FireflySlider;
    #endregion

    private void Awake()
    {
        playerLight = GetComponent<Light2D>();
        originalRange = playerLight.pointLightOuterRadius;
        currFirefly = 0;
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
        FireflySlider.value += 1;
    }
}
