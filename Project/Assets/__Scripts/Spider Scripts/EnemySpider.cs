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
            PlayerMovement.health--;
            if(PlayerMovement.health<=0)
            {
                Destroy(target.gameObject);
            }
        }
    }

    public virtual void TakeDamage(float damage)// virutal class to be overrided in the sub-classes
    {

    }
}
