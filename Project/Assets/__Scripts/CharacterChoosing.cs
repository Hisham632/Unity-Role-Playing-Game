using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoosing : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private CameraController camera;
    public static GameObject character;


    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(-59, 4.2f, 0);
        int characterToSpawn = PlayerPrefs.GetInt("CharacterSelected");

        if (characterToSpawn == 0)
        {
            character = Instantiate(player1, transform.position, Quaternion.identity);

        }
        else if (characterToSpawn == 1)
        {
            character = Instantiate(player2, transform.position, Quaternion.identity);

        }

    }


}
