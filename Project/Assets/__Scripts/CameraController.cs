using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("FeetPos").transform;// so the camera follows the Player's movement  //hello
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y + 4f;
           
            transform.position = temp;

        }
    }
}
