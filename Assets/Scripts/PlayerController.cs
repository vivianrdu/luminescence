using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    float x_input;
    float y_input;
    #endregion

    #region Physics_components
    Rigidbody2D PlayerRB;
    #endregion

    #region Unity_functions
    #endregion

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();
    }

    #region Movement_functions
    private void Move()
    {
        if (x_input > 0)
        {
            PlayerRB.velocity = Vector2.right * movespeed;
        } else if (x_input < 0)
        {
            PlayerRB.velocity = Vector2.left * movespeed;
        } else if (y_input > 0)
        {
            PlayerRB.velocity = Vector2.up * movespeed;
        } else if (y_input < 0)
        {
            PlayerRB.velocity = Vector2.down * movespeed;
        } else
        {
            PlayerRB.velocity = Vector2.zero;
        }
    }
    #endregion
}
