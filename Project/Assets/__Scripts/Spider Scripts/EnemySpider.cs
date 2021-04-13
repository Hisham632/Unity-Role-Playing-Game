using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{

    public static int ememiesKilled;
    void OnCollisionEnter2D(Collision2D target)// used to kill the player if they touch the spider
    {
        if (target.gameObject.tag == "Player")// if it has the Player gameTag it will kill him
        {
            PlayerMovement.HEALTH--;// decreases the player's health everytime hes hit by an enemy
            if(PlayerMovement.HEALTH <= 0)// if the player's health is 0 he dies
            {
                Destroy(target.gameObject);
            }
        }
    }

    public virtual void TakeDamage(float damage)// virutal class to be overrided in the sub-classes
    {

    }
}
