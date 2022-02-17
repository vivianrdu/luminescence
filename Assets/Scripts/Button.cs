using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float radius;
    public Animator anim;
    public Transform rock;

    private void Update()
    {
        // check if we know where rock is
        if (rock == null)
        {
            return;
        }
        else
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.CompareTag("Rock"))
                {
                    GetComponent<Animator>().SetBool("pushed", true);
                }
                else
                {
                    GetComponent<Animator>().SetBool("pushed", false);
                }
            }
        }
    }
}
