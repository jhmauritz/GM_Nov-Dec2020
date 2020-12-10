using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class C_LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    //public Transform spawnPoint;
    public Text label;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = StaticHolder.SELECTEDCHAR;
        GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        label.text = prefab.name;
        prefab = StaticHolder.SINGLEPLAYERCHAR;
        Debug.Log(" is selected");
        
        //jesse wrote this (we can have it so they can pick keyboard or mouse if time permits,
        //but this will make sure they are using the main first person controls
        var input = prefab.GetComponent<PlayerInput>();
        input.user.ActivateControlScheme("KeyBoard - 1");

        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            if (characterPrefabs[i].name == prefab.name)
            {
                return;
            }
            else
            {
                characterPrefabs[i].transform.position = StaticHolder.UNSELECTEDCHAR_POS;
                characterPrefabs[i].transform.rotation = StaticHolder.UNSELECTEDCHAR_ROT;
                if (StaticHolder.GAMEMODE == 1)
                {
                    characterPrefabs[i].SetActive(true);
                }
            }
        }
    }
}
