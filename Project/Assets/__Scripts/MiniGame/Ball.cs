using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D _rb;//rigidbody
 
     // Use this for initialization*/
    void Start()
    {

        Respawn();//calls the Respawn function
    }

   
    public void Respawn()
    {
        _rb = GetComponent<Rigidbody2D>();// gets the RigidBody2D component
        transform.position = Vector3.zero;
        _rb.velocity = Random.insideUnitCircle * speed;//gives the ball a velocity in a random direction at the start
    }
}
