using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public float offset;
    public GameObject fireball;
    public float lauchForce;
    public Transform shotPoint;// the point where the arrows launch from
    private float _timeBtwShots;
    public float startTimeBtwShots;// the time between shots, so the player can't just spam shooting


    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (_timeBtwShots <= 0)// makes sure the player can only shoot fireBalls when the timeBtwShots is over
        {
            if (Input.GetMouseButtonDown(0))// shoots fireBalls when mouse left click is clicked
            {
                Instantiate(fireball, shotPoint.position, transform.rotation);
                _timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;// decreases the time
        }


    }

    private void Shoot()
    {
        GameObject newFireball = Instantiate(fireball, shotPoint.position, shotPoint.rotation);// instantiates a new fireBall
        newFireball.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;// launches the fireball

    }
  


}
