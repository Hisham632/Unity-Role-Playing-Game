using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public static int point=0;

    void Start()
    {
        if (Door.instance != null && MiniGameDoor.instance != null)// makes sure the the Door INSTANCE variable is not null
        {
            Door.instance.collectablesCount++; //when the gameObject touches the player increment collectablesCount value
         //   MiniGameDoor.instance.collectablesCount++;
        }

    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")  // We assigned each specific GameObject (prefab) a unique tag to identify it, so when the OnTriggerEnter2D method is called it checks 
        {                             // if the  tag corresponds the pickup that was triggered and enters the if statement 

            if (gameObject.tag == "Diamond1")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                point++;
                PlayerMovement.health += .1f;
            }
            else if (gameObject.tag == "Diamond2")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                point+=2;
                PlayerMovement.health += .2f;

            }
            else if (gameObject.tag == "Diamond3")
            {
                Destroy(gameObject);// We destroy the pickup GameObject when it's triggered
                point+=3;
                PlayerMovement.health += .4f;
            }

        //    Debug.Log("Score: " + point);//TEXT
        //    Debug.Log("Health: " + PlayerMovement.health);//TEXT

             if (Door.instance != null && MiniGameDoor.instance != null)// makes sure the the Door INSTANCE variable is not null
             {
                 Door.instance.DecremenetCollectables();// when the gameObject touches the player we call DecremenetCollectables() in Door class
              //   MiniGameDoor.instance.PointsDoor();
             }

        }
    }
}
