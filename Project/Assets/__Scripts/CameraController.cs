using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = CharacterChoosing.CHARACTER.transform;//depending on what character the user chooses we assign it to player so the camera follow him

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)//updates the cameras position to always view the player
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y + 4f;

            transform.position = temp;

        }
    }
}
