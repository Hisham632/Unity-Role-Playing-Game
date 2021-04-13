using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball: MonoBehaviour
{

    private Rigidbody2D _rb;
    public float speed;
    private bool _hasHit;
    public int damage;
    public float lifeTime;
    public GameObject destroyEffect; 
    


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);// Invoke the projectile with a set lifeTime which will destroy itself after
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
      if (_hasHit == false)// as long as the fireBall hasnt hit anything it will continue on its trajectory
        {
            float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }

    void DestroyProjectile()// destroys the gameObject
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)// if it hits a GameObject that only has a collider then it will stop
    {
        _hasHit = true;
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;
        if (collision.gameObject.CompareTag("Player_2"))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)// gets the spider and decreases its health till its 0 and kills it
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemySpider>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }



}
