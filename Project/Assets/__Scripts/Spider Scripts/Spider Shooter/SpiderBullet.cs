using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{


    // take Collider 2D as a target
    void OnTriggerEnter2D(Collider2D target) {
        // if target.tag = player we are going to destroy the player and the bullet itself
        if(target.tag == "Player") {
            // desroying the player
            Destroy(target.gameObject);
            // destroying the bullet
            Destroy(gameObject);

        }
        // if target.tag = Ground which means if it hits the groud, we will destroy the bullet
        if(target.tag == "Ground") {
            Destroy(gameObject);
        }
    }
  
}
