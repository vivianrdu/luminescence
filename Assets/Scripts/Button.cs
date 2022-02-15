using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float radius;
    public Animator anim;
    public GameObject Rock;

    #region Animation_functions
    private void PushButton()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Rock"))
            {
                GetComponent<Animator>().SetBool("pushed", true);
            }
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Rock"))
        {
            PushButton();
        }
    }
    #endregion
}
