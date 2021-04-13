using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    // Start is called before the first frame update
    private int index;
    void Start()
    {
        characterList = new GameObject[transform.childCount];// gets the character list
        for (int i = 0; i < transform.childCount; i++)//loops through the characters
            characterList[i] = transform.GetChild(i).gameObject;
        foreach (GameObject go in characterList)
            go.SetActive(false);
        if (characterList[0])
            characterList[0].SetActive(true);

    }
    public void ToggleRight()// to go right in the list
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 0;
        characterList[index].SetActive(true);
    }
    public void ToggleLeft()// to go left in the list
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;
        characterList[index].SetActive(true);
    }
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected",index);
        SceneManager.LoadScene("se2250_group_phase1");//loads the game scene
    }

    
    
}
