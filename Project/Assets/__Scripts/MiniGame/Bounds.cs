using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)// if it hits the bottom wall which has an OnTrigger it'll call the respawn function in the ball script
    {
        collision.GetComponent<Ball>().Respawn();
    }
}
