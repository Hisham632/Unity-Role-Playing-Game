using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoosing : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private CameraController cam;

  

    // Start is called before the first frame update
    void Start()
    {

        cam.GetComponent<CameraController>();
        transform.position = new Vector3(-59, 4.2f, 0);
        int characterToSpawn = PlayerPrefs.GetInt("CharacterSelected");
        if(characterToSpawn==0)
        {
            Instantiate(player1, transform.position, Quaternion.identity);

            cam.player = player1.transform;



        }
        else if (characterToSpawn == 1)
        {
            Instantiate(player2, transform.position, Quaternion.identity);
            cam.player = player2.transform;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
