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
        player = CharacterChoosing.character.transform;

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
