using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Rigidbody2D _rb;
    private bool _hasHit;
    public int damage;
    private float _angle;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();// gets the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if(_hasHit == false)// as long as the arrow hasnt hit anything it will continue on its trajectory
        {
            _angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)// if it hits a GameObject that only has a collider then it will stop
    {
        _hasHit = true;
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)// if it hits a GameObject that that has  trigger activated then it will damage it if its an enemy
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemySpider>().TakeDamage(damage);// gets the spider and decreases its health till its 0 and kills it
            Destroy(gameObject);
        }

    }


}
