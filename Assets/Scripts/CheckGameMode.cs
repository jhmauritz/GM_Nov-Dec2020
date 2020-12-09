using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CheckGameMode : MonoBehaviour
{
    [SerializeField] private GameObject singlePlayerCamera;
    [SerializeField] private GameObject multiplayerCamera;

    private void Start()
    {
        if (SC_MainMenu.gameMode == 0)
        {
            return;
        }
        else if (SC_MainMenu.gameMode == 1)
        {
            SinglePlayer();
        }
        else if (SC_MainMenu.gameMode == 2)
        {
            Multiplayer();
        }
    }

    void SinglePlayer()
    {
        //set camera active
        multiplayerCamera.SetActive(false);
        singlePlayerCamera.SetActive(true);

        //focus on character
        CinemachineVirtualCamera singleCam = singlePlayerCamera.GetComponentInChildren<CinemachineVirtualCamera>();
        
        
    }

    void Multiplayer()
    {
        //set camera active
        multiplayerCamera.SetActive(true);
        singlePlayerCamera.SetActive(false);
    }
}
