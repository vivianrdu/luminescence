using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject button;
    private Color doorColor;
    public float fadeSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        doorColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    private void Update()
    {
        float totalTransitionTime = 4.0f;

        Color clearState = Color.clear;

        Debug.Log(button.GetComponent<Animator>().GetBool("pushed").ToString());


        if (button.GetComponent<Animator>().GetBool("pushed") == true)
        {
            Debug.Log("Start Disappear");
            //StartCoroutine(Disappear(doorColor, clearState, totalTransitionTime));
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, clearState, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            Debug.Log("Start Appear");
            //StartCoroutine(Appear(clearState, doorColor, totalTransitionTime));
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, doorColor, fadeSpeed * Time.deltaTime);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    #region Coroutines
    IEnumerator Disappear(Color startState, Color endState, float totalTransitionTime)
    {
        Debug.Log("Disappear triggered");

        float elapsedTime = 0.0f;

        while (startState != endState)
        {
            Debug.Log("Changing color");
            GetComponent<SpriteRenderer>().color = Color.Lerp(startState, endState, elapsedTime / totalTransitionTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(this.gameObject);
    }

    IEnumerator Appear(Color startState, Color endState, float totalTransitionTime)
    {
        Debug.Log("Appear triggered");

        float elapsedTime = 0.0f;

        while (startState != endState)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(startState, endState, elapsedTime / totalTransitionTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (GameObject.Find("Door1") == null)
        {
            Instantiate(this.gameObject);
        }
    }
    #endregion
}
