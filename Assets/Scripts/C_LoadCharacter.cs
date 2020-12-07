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
        //GameObject clone = Instantiate(prefab.spawnPoint.position, Quanternion.identity);
        label.text = prefab.name;
    }
}
