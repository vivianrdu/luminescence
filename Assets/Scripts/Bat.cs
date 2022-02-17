using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Bat : MonoBehaviour
{
    #region Physics_components
    Rigidbody2D BatRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    #endregion

    #region Trigger_variables
    public float batRadius;
    #endregion

    #region Unity_functions

    // runs once on creation
    private void Awake()
    {
        BatRB = GetComponent<Rigidbody2D>();
    }

    //runs once every frame
    private void Update()
    {
        // check to see if we know where the player is
        if (player == null)
        {
            return;
        }
    }
    #endregion

    // Raycasts box for player, disappears when player collects all fireflies
    #region Collected_functions
    private void Fly()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, batRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player") && (hit.transform.GetComponentInChildren<Light2D>().pointLightOuterRadius == 12))
            {
                Destroy(this.gameObject);
                Debug.Log("Bat flew away");
            } else
            {
                Debug.Log("Not enough fireflies");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Fly();
            Debug.Log("Player detected in nearby");
        }
    }
    #endregion
}
