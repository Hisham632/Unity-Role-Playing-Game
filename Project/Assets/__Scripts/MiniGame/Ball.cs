using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;
 
     // Use this for initialization*/
    void Start()
    {

        Respawn();
    }

   
    public void Respawn()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = Vector3.zero;
        rb.velocity = Random.insideUnitCircle * speed;
    }
}
