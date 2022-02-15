using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyLineOfSight : MonoBehaviour
{
    // called when something enters the trigger collider
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // check if coll is the player
        if (coll.CompareTag("Player"))
        {
            GetComponentInParent<Firefly>().player = coll.transform;
            Debug.Log("See Firefly move towards Player");
        }
    }
}
