using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CheckGameMode : MonoBehaviour
{
    [SerializeField] private GameObject singlePlayerCamera;
    //[SerializeField] 
    [SerializeField] private GameObject multiplayerCamera;

    [SerializeField] private GameObject enemy;
    private float singlePlayerTimer = 4f;
    private bool singleplayer = false;

    private void Start()
    {
        Debug.Log(StaticHolder.GAMEMODE);
        
        if (StaticHolder.GAMEMODE == 0)
        {
            return;
        }
        else if (StaticHolder.GAMEMODE == 1)
        {
            SinglePlayer();
        }
        else if (StaticHolder.GAMEMODE == 2)
        {
            Multiplayer();
        }
    }

    private void Update()
    {
        if (singleplayer)
        {
            singlePlayerTimer -= Time.deltaTime;
            if (singlePlayerTimer <= 0)
            {
                singleplayer = false;
                TransitionToPlayerCam();
            }
        }
    }

    void SinglePlayer()
    {
        
        Debug.Log("singleplayer");
        
        singleplayer = true;
        
        //set camera active
        multiplayerCamera.SetActive(false);
        singlePlayerCamera.SetActive(true);
        
        var enemySpawned = Instantiate(enemy, StaticHolder.UNSELECTEDCHAR_POS, StaticHolder.UNSELECTEDCHAR_ROT);

        //focus on character
        SinglePlayerCam cam = singlePlayerCamera.GetComponent<SinglePlayerCam>();
        cam.playerCam.Follow = StaticHolder.SINGLEPLAYERCHAR.transform;
        cam.playerCam.LookAt = StaticHolder.SINGLEPLAYERCHAR.transform;

        cam.EnemyCam.Follow = enemySpawned.transform;
        cam.EnemyCam.LookAt = enemySpawned.transform;
        //maybe have a camera pan over to see the enemy first

    }

    void Multiplayer()
    {
        Debug.Log("multiplayer");
        
        //set camera active
        multiplayerCamera.SetActive(true);
        singlePlayerCamera.SetActive(false);
    }

    void TransitionToPlayerCam()
    {
        SinglePlayerCam cam = singlePlayerCamera.GetComponent<SinglePlayerCam>();
        cam.playerCam.Priority = 1;
        cam.EnemyCam.Priority = 0;
    }
}
