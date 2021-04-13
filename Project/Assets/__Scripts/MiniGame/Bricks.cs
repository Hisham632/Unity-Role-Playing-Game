using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bricks : MonoBehaviour
{
    public static int SCORE;//declared static so all the bricks have the same score

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);//When the ball hits the brick, it destroys itself
             SCORE++;//adds the score
            if (SCORE == 3)// For the demo we put if it hits 3 bricks you win and go back to level 2
            {
                SceneManager.LoadScene("Level2");
            }
        

    }


   
   
}
