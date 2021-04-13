using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public float offset2;
    private Transform _aimTransform;
    private Camera _camera;
    public GameObject arrow;
    public float lauchForce;
    public Transform shotPoint;// the point where the arrows launch from
    private float _timeBtwShots;
    public float startTimeBtwShots;// the time between shots, so the player can't just spam shooting
    private float _angle;


    // Start is called before the first frame update
    void Awake()
    {
        _aimTransform = transform.Find("BowAim");// gets the position of BowAim GameObject
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;// gets the mouse position so it follows the cursor 
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset1 = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        _angle = Mathf.Atan2(offset1.y, offset1.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _angle * offset2);// used to rotate the bow so the player can shoot at different angles


        if(_timeBtwShots <= 0)// makes sure the player can only shoot arrows when the timeBtwShots is over
        {
            if (Input.GetMouseButtonDown(0))// shoots arrows when mouse left click is clicked
            {
                Shoot();
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
        GameObject newArrow=Instantiate(arrow, shotPoint.position, shotPoint.rotation);// instantiates a new arrow 
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * lauchForce;// lauches it 

    }


}
