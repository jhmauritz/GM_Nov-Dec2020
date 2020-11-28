using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerScript>())
        {
            other.GetComponent<PlayerScript>().isPlayerNearItem = true;
            other.GetComponent<PlayerScript>().itemScript = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerScript>())
        {
            other.GetComponent<PlayerScript>().isPlayerNearItem = false;
            //other.GetComponent<PlayerScript>().itemScript = null;
        }
    }
}
