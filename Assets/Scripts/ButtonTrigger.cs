using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Button triggerButton;
    public Animator animator;

    void Update()
    {
    
    }

    public void nextScene()
    {
        animator.SetTrigger("FadeOut");
        Debug.Log("Click");
    }
}
