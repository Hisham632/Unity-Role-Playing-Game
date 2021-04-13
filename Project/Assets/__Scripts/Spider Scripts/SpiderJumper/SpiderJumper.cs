using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : EnemySpider
{
    private Rigidbody2D _myBody;
    public float forceY = 300f;// has a force of 300
    public float health;

    public GameObject point1;
    public GameObject point2;

    // Start is called before the first frame update
    void Start()
    {
        _myBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));// waits a random amount of time between 2 to 7sec

        forceY = Random.Range(250f, 550f); // jumps a random height the range
        _myBody.AddForce(new Vector2(0, forceY));

        yield return new WaitForSeconds(.7f);// waits .7sec then repeats
        StartCoroutine(Attack());// we need to pass the attack and allow call it again continously 


    }



    void Update()
    {
        if(health<=0)// if health reaches 0 it'll destroy
        {
            Destroy(gameObject);
            for (int i = 1; i <= 2; i++)
            {
                if(i==1)
                {
                    Instantiate(point1,  new Vector3((float)(transform.position.x+1), transform.position.y, transform.position.z) , Quaternion.identity);
                }
                if (i == 2)
                {
                    Instantiate(point2, new Vector3((float)(transform.position.x-1), transform.position.y, transform.position.z), Quaternion.identity);
                }
            }
            ememiesKilled++;

        }
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;//decrease the health
        Debug.Log("Damage " + damage);
        Debug.Log("Health: " + health);
    }
}












