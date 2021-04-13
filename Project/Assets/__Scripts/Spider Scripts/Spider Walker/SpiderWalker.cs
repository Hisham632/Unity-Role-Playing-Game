using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spider
{
    public class SpiderWalker : EnemySpider
    {
        public float health;

        public GameObject point1;
        public GameObject point2;
        public GameObject point3;


        [SerializeField]
        public Transform startPos, endPos;// start and end position of where the Spider GameObject walks 
        private bool _collision; // to detect when to change directions
        public float speed = 1f;
        private Rigidbody2D _myBody;

        void Awake()
        {
             _myBody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Move();// calls the Move() method
            ChangeDirection(); // calls the ChangeDirection() method
         }

        void ChangeDirection()
        {
          _collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground")); //used to detect if spider is still colliding with the ground layer

            Debug.DrawLine(startPos.position, endPos.position, Color.blue);// so it changes direction when it reaches the endPosition and shows a blue color for the line  

            if (!_collision) //if there is no longer collision( is not at one of the ends)
            {
                Vector3 temp = transform.localScale;
                if(temp.x == 1f) //checks to see if its going in the right direction 
                {
                    temp.x = -1f; //changes the direction to face opposite side(left side)
                }
                else
                {
                    temp.x = 1f;//changes the direction to face opposite side(right side)
                    }

                transform.localScale = temp; //reset location
            }
        }

        void Move()
        {
            _myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;// to move the player
        }

        void Update()
        {
            if (health <= 0)// if health reaches 0 it'll destroy
            {
                Destroy(gameObject);
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 1)
                    {
                        Instantiate(point1, new Vector3((float)(transform.position.x + 1), transform.position.y, transform.position.z), Quaternion.identity);
                    }
                    if (i == 2)
                    {
                        Instantiate(point2, new Vector3((float)(transform.position.x - 1), transform.position.y, transform.position.z), Quaternion.identity);
                    }
                    if (i == 3)
                    {
                        Instantiate(point3, new Vector3(transform.position.x , transform.position.y+2, transform.position.z), Quaternion.identity);
                    }
                }
                ememiesKilled++;

            }
        }
        public override void TakeDamage(float damage)
        {
            health -= damage;//decrease the health
            Debug.Log("Damage "+damage);
            Debug.Log("Health: " +health);

        }
    }
}