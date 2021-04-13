 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : EnemySpider
{
    [SerializeField]
    public float health;
    public GameObject Bullet;
    public GameObject point1;

    // Start is called before the first frame update
    void Start()
    {
        // we call this in the start function so it can start shooting right when the game starts.
        StartCoroutine(Attack());

    }


    // in order to shoot the bullet
    IEnumerator Attack() 
    {
        yield return new WaitForSeconds(Random.Range(2,7)); // waits for random number of seconds between 2 and 7
        
        Instantiate(Bullet, transform.position, Quaternion.identity);// instantiates the bullet

        // we need to pass the attack and allow call it again continously 
        StartCoroutine(Attack());
    }

    void Update()
    {
        if (health <= 0)// if health reaches 0 it'll destroy
        {
           Destroy(gameObject);
          
           Instantiate(point1, this.transform.position, Quaternion.identity);
            ememiesKilled++;

        }
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;//decrease the health
    }
}
