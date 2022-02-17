using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    private Color doorColor;
    public float fadeSpeed;

    private void Start()
    {
        doorColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        Color clearState = Color.clear;

        bool button1_open = button1.GetComponent<Animator>().GetBool("pushed");
        bool button2_open = button2.GetComponent<Animator>().GetBool("pushed");

        Debug.Log(button1_open.ToString());
        Debug.Log(button2_open.ToString());

        if ((button1_open == true) & (button2_open == true))
        {
            Debug.Log("Disappear");
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, clearState, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Debug.Log("Appear");
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, doorColor, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

