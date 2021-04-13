using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;

    private float _inputAxis;
    private Rigidbody2D _rb;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetScore();// displays the score to be 0 at the start

    }

    // Update is called once per frame
    void Update()
    {
        _inputAxis = Input.GetAxisRaw("Horizontal");// gets the axis
        _rb.velocity = Vector2.right * _inputAxis * speed;//to move the paddle


    }

    private void SetScore() // SetScore() method 
    {
        score.text = "Score: " + Bricks.SCORE.ToString(); // changes the score text each time a pickup GameObject is picked to display it 

    }


}
