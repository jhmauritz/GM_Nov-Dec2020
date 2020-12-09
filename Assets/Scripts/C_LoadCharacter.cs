using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    //public Transform spawnPoint;
    public Text label;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        label.text = prefab.name;
        Debug.Log("Player is selected");
        
        //jesse wrote this (we can have it so they can pick keyboard or mouse if time permits,
        //but this will make sure they are using the main first person controls
        prefab.GetComponent<PlayerInputs>();
    }
}
