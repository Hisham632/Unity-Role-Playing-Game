using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public  float speed;
    private float _moveAxis;
    private bool _isGrounded;// checks if its in the gorund
    public Transform feetpos;// transform for the feet positon
    public float checkRadius;
    public float jumpForce;

    private float _jumpTimeCounter;
    public float jumpTime;// for how long it stays in the air jumping
    private bool _isJumping;// checks if its jumping
    private Animator _anim;// for animation

    public static float MAX_HEALTH = 5;// the maxHealth value

    public static float HEALTH = 5;
    private int _points = DiamondScript.POINT;
    public HealthBar healthBar;//Health Bar
    public TextMeshProUGUI score;// Text variable score used to display the score 


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();// gets the rigidbody component 
        _anim = GetComponent<Animator>();  // Passing the animator because we want to get the animator component
    }

    private void Start()
    {
        healthBar.SetMaxHealth(MAX_HEALTH);//calls the SetMaxHealth function in the healthBar class to set the max value of the bar
        SetScore();// displays the score to be 0 at the start
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveAxis = Input.GetAxisRaw("Horizontal");// gets the respective axis 
        _rb.velocity = new Vector2(_moveAxis * speed, _rb.velocity.y);// sets the player's velocity
    }

    void Update()
    {

        _isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius);// checks if the player is in the ground

        if (_moveAxis > 0)// if its moving to the right shifts the player to the correct direction
        {
            _anim.SetBool("Walk", true);// sets the walking animation 

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_moveAxis < 0)// if its moving to the left shifts the player to the correct direction
        {
            _anim.SetBool("Walk", true);// sets the walking animation 
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else// otherwise if its not moving dont play the walking animation
        {
            _anim.SetBool("Walk", false);

        }

        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))// if the player is on the ground then allow the player to jump if he presses the spaceBar
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;//resets the jumpTimeCounter
            _rb.velocity = Vector2.up * jumpForce;


        }

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {

            if (_jumpTimeCounter > 0)//allows to jump if the JumpTimer is greater than 0
            {
                _rb.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;// otherwise its not
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))// releases teh spaceBar
        {
            _isJumping = false;
        }

        SetSpeed();//calls the SetSpeed function
        SetScore();//calls the SetScore function

        healthBar.SetHealth(HEALTH);//calls the SetHealth to set the current health to the bar
        if(HEALTH > MAX_HEALTH)// if the current health is greater than the maxHealth then it sets that as the new maxValue
        {
            healthBar.SetMaxHealth(HEALTH);
            MAX_HEALTH = HEALTH;
        }
        SetScore();//calls the SetScore function

    }

    private void SetSpeed()
    {
        if(_points<DiamondScript.POINT)// if the player collects diamonds, he's speed will increase by .05*#ofPoints and it'll reset
        {
            speed = speed + .05f * DiamondScript.POINT;
            _points = DiamondScript.POINT;

        }
    }

    private void SetScore() // SetScore() method 
    {
        score.text = "Score: " +  DiamondScript.POINT.ToString(); // changes the score text each time a pickup GameObject is picked to display it 

    }

    public void BouncePlayer(float force)//if the player hits the bouncer pad, he'll be launched upwards
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, force));
        }
    }
}