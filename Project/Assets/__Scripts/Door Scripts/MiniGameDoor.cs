using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameDoor : MonoBehaviour
{

    public static MiniGameDoor instance;
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

    void Start()
    {
        OpenDoor();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

  /*  public void PointsDoor()
        {
           if (DiamondScript.point == 0) //when at least one collectable has been collected
            {
                StartCoroutine(OpenDoor()); //open door
            }
        }
  */
    

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
            Debug.Log("Going to MiniGame");// prints Game Finished in the Log
        }
        if (target.tag == "Player" || target.tag == "Player2")
        {
            if (gameObject.tag == "Door2")
            {
                SceneManager.LoadScene("MiniGame");
            }


        }
    }
}
