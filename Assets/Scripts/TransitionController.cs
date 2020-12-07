using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    private PlayerScript[] players;

    public float numberLessThanToTransition;


    public static bool isTransition;
    public static float sum;

    [SerializeField] private CinemachineVirtualCamera vcam1; // happy world
    [SerializeField] private CinemachineVirtualCamera vcam2; // hell world
    [SerializeField] private GameObject[] floor1; // happy floor
    [SerializeField] private GameObject[] floor2; // hell floor

    private void Awake()
    {
        players = FindObjectsOfType<PlayerScript>();
    }

    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].health <= numberLessThanToTransition)
            {
                TransitionToHell();
                isTransition = true;
                Debug.Log("transition");
                break;
            }
        }
    }
    
    void TransitionToHell()
    {
        vcam1.Priority = 0;
        vcam2.Priority = 1;
        for (int i = 0; i < floor1.Length; i++)
        {
            floor1[i].SetActive(false);
        }

        for (int i = 0; i < floor2.Length; i++)
        {
            floor2[i].SetActive(true);
        }
    }
}
