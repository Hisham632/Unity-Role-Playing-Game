using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public static int POINT=0;

    void Start()
    {
        if (Door.instance != null && MiniGameDoor.instance != null)// makes sure the the Door INSTANCE variable is not null
        {
            Door.instance.collectablesCount++; //when the gameObject touches the player increment collectablesCount value
        }

    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")  // We assigned each specific GameObject (prefab) a unique tag to identify it, so when the OnTriggerEnter2D method is called it checks 
        {                             // if the  tag corresponds the pickup that was triggered and enters the if statement 

            if (gameObject.tag == "Diamond1")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                POINT++;
                PlayerMovement.HEALTH += .1f;//adds .1 to the player's health
            }
            else if (gameObject.tag == "Diamond2")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                POINT += 2;
                PlayerMovement.HEALTH += .2f;//adds .2 to the player's health

            }
            else if (gameObject.tag == "Diamond3")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                POINT += 3;
                PlayerMovement.HEALTH += .4f;//adds .4 to the player's health
            }

             if (Door.instance != null && MiniGameDoor.instance != null)// makes sure the the Door INSTANCE variable is not null
             {
                 Door.instance.DecremenetCollectables();// when the gameObject touches the player we call DecremenetCollectables() in Door class
             }

        }
    }
}
