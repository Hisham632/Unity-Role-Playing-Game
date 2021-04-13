using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public static Door instance;
    private BoxCollider2D _box;
    private Animator _anim;

    [HideInInspector]
    public int collectablesCount;// number of collectables

    void Awake()
    {
        MakeInstance();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DecremenetCollectables()
    {
        collectablesCount--; 
        if(collectablesCount == 0 &&(gameObject.tag =="Door1" || gameObject.tag == "Door4") ) //when all collectables have been collected
        {
            StartCoroutine(OpenDoor()); //open door
        }
    }
    
    IEnumerator OpenDoor()
    {
        _anim.Play("Open"); // plays the opening door animation 
        yield return new WaitForSeconds(.7f);
        _box.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player" || target.tag == "Player2") // when the character enters through a door the game ends 
        {
            Debug.Log("Game Finished");// prints Game Finished in the Log
        }
        if(target.tag == "Player" || target.tag == "Player2")
        {
            if (gameObject.tag == "Door1")
            {
                SceneManager.LoadScene("Level2");
            }
          /*  else if(gameObject.tag == "Door2")
            {
                SceneManager.LoadScene("MiniGame");
            }
            else if(gameObject.tag == "Door3")
            {
                SceneManager.LoadScene("Level2");
            }
          */
            else if(gameObject.tag == "Door4")
            {
                //escaped the cave
                Debug.Log("You have escaped the cave!");

            }

        }
    }
}
