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

    public static float maxHealth = 5;

    public static float health = 5;
    private int points = DiamondScript.point;

    public HealthBar healthBar;

    public TextMeshProUGUI score;// Text variable score used to display the score 


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();// gets the rigidbody component 
        _anim = GetComponent<Animator>();  // Passing the animator because we want to get the animator component
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        SetScore();
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
            _jumpTimeCounter = jumpTime;
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
                _isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))// releases teh spaceBar
        {
            _isJumping = false;
        }

        setSpeed();
        healthBar.SetHealth(health);
        if(health>maxHealth)
        {
            healthBar.SetMaxHealth(health);
            maxHealth = health;
        }
        SetScore();
        Debug.Log(score.text);

    }

    private void setSpeed()
    {
        if(points<DiamondScript.point)
        {
            speed = speed + .05f * DiamondScript.point;
            points = DiamondScript.point;

        }
      //  Debug.Log("Speed: " + speed);//TEXT
    }

    private void SetScore() // SetScore() method 
    {
        score.text = "Score: " +  DiamondScript.point.ToString(); // changes the score text each time a pickup GameObject is picked to display it 
        
        
        /*if(_countOfPickups >= numOfPickups) // checks if all the pickup GameObjects have been picked up 
        {
            Time.timeScale = 0;// assigning Time.timeScale=0 to pause the game
            gameOver.text = "You Win!!!"; // if all the pickup GameObjects have been picked up it displays the corresponding text
            StartCoroutine(Wait()); // We start the Coroutine and call the Wait() method
        }*/

    }

    /*
    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3); // waits 3 seconds, we use WaitForSecondsRealtime so timeScale=0 doesnt affect it 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// restarts the game after waiting 3 seconds
        Time.timeScale = 1;// assigning Time.timeScale=1 to resume the game after it restarts
    }*/

    public void BouncePlayer(float force)
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, force));
        }
    }
}