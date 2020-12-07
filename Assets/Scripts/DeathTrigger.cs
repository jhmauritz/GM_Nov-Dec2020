using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            other.gameObject.GetComponent<PlayerScript>().TakeDamage(
                other.gameObject.GetComponent<PlayerScript>().health);
        }
    }
}
