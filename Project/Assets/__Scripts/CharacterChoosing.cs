using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoosing : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public static GameObject CHARACTER;


    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(-59, 4.2f, 0);
        int characterToSpawn = PlayerPrefs.GetInt("CharacterSelected");//gets which preFab did the user select

        if (characterToSpawn == 0)// if he chooses the first character then the first one is instantiated 
        {
            CHARACTER = Instantiate(player1, transform.position, Quaternion.identity);

        }
        else if (characterToSpawn == 1)// if he chooses the second character then the second one is instantiated 
        {
            CHARACTER = Instantiate(player2, transform.position, Quaternion.identity);

        }

    }


}
