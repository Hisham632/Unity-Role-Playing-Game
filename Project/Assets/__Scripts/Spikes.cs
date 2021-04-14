using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private PlayerMovement _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //When this is called, it will give us the collider we touched as a parameter
        //We can touch lots of different colliders, so before we try to deal damage lets check what we are colliding with
        //This assumes that the player gameobject has been given a tag called "Player"
        if (col.CompareTag("Player"))
        {
            //If we are colliding with the player, then you can now deal damage.
            //Do this however you want. Usually you will want to access some component on the player gameobject, then call a function that deals damage.
            Destroy(col.gameObject);
        }
    }
}
