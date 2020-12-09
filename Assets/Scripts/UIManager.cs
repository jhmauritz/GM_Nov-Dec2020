using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject playerOne;
    public TextMeshProUGUI playerOneText;
    
    private GameObject playerTwo;
    public TextMeshProUGUI playerTwoText;

    private void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerOneText.text = "0";
        
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        playerTwoText.text = "0";
    }

    private void Update()
    {
        playerOneText.text = StaticHolder.PONEWINS.ToString("F0");
        playerTwoText.text = StaticHolder.PTWOWINS.ToString("F0");

        if (playerOne == null || playerTwo == null)
        {
            Invoke("ReloadScene" , 1.0f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
