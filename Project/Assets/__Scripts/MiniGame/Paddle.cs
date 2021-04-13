using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;

    private float _inputAxis;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        _inputAxis = Input.GetAxisRaw("Horizontal");// gets the axis
        _rb.velocity = Vector2.right * _inputAxis * speed;//to move the paddle


    }

  


}
