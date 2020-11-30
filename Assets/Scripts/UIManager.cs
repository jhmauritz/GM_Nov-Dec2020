using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject playerOne;
    public static int playerOneWins;
    public TextMeshProUGUI playerOneText;
    
    private GameObject playerTwo;
    public static int playerTwoWins;
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
        playerOneText.text = playerOneWins.ToString("F0");
        playerTwoText.text = playerTwoWins.ToString("F0");

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
