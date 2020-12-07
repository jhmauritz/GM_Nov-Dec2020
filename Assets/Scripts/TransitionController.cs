using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    private PlayerScript[] players;

    public float numberLessThanToTransition;

    public static float sum;

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
                Debug.Log("transition");
                break;
            }
        }
    }
}
