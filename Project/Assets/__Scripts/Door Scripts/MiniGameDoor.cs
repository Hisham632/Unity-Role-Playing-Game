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
        OpenDoor(); //open the door
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
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
        if (target.tag == "Player" || target.tag == "Player2") // when the character enters through a door 
        {
            if (gameObject.tag == "Door2") //if it is door 2
            {
                SceneManager.LoadScene("MiniGame"); //load the minigame
            }


        }
    }
}
