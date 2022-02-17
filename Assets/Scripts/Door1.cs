using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public GameObject button;
    private Color doorColor;
    public float fadeSpeed;

    private void Start()
    {
        doorColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        Color clearState = Color.clear;

        if (button.GetComponent<Animator>().GetBool("pushed") == true)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, clearState, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, doorColor, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
