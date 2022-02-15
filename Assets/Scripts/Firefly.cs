using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Physics_components
    Rigidbody2D FireflyRB;
    #endregion

    #region Targeting_variables
    public Transform player;
    #endregion

    #region Trigger_variables
    public float collectRadius;
    #endregion

    #region Unity_functions

    // runs once on creation
    private void Awake()
    {
        FireflyRB = GetComponent<Rigidbody2D>();
    }

    //runs once every frame
    private void Update()
    {
        // check to see if we know where the player is
        if (player == null)
        {
            return;
        }

        Move();
    }
    #endregion

    #region Movement_functions

    // when player enters radius, move towards player jar and disappear (destroy)
    private void Move()
    {
        //Calculate movement vector player position - enemy position
        Vector2 direction = player.position - transform.position;
        FireflyRB.velocity = direction.normalized * movespeed;
    }
    #endregion

    // Raycasts box for player, disappears when player collects the firefly
    #region Collected_functions
    private void Collected()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, collectRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                //move towards player
                Move();
                // if player is in FireflyRB radius disappear
                Destroy(this.gameObject);
                Debug.Log("Firefly collected");
            }
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Collected();
            Debug.Log("Player detected in collectRadius");
        }
    }
    #endregion
}
