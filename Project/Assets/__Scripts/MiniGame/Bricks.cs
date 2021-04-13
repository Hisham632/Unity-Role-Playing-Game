using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bricks : MonoBehaviour
{
    public static int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {

       
            Destroy(gameObject);
            score++;
            Debug.Log(score);
            if (score == 3)
            {
                SceneManager.LoadScene("Level2");
            }
        

    }
}
