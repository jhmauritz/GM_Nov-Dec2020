using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingTrigger : MonoBehaviour
{
    public bool isHittingEnemy;

    private void Awake()
    {
        Collider[] colliders = GetComponentsInParent<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i; j < colliders.Length; j++)
            {
                Physics.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            isHittingEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            isHittingEnemy = false;
        }
    }
}
