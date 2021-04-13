using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;

    private float inputAxis;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        inputAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * inputAxis * speed;


    }

  


}
