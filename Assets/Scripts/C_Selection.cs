using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_Selection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        //jesse trying something if i broke uncomment and proceed toi yell at me
        //PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        StaticHolder.SELECTEDCHAR = selectedCharacter;
        UnityEngine.SceneManagement.SceneManager.LoadScene("prototyping");
    }
   
}
