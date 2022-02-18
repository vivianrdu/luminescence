using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && (mousePos.x > 738) && (mousePos.x < 915)
            && (mousePos.y > 200) && (mousePos.y < 300) && (SceneManager.GetActiveScene().name == "StartMenu"))
        {
            FadeToLevel();
        }

    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
