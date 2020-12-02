using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public float knockbackForce;
    public float damage;

    public float lifeTimer;
    private Animator anim;


    public float spawnChance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 3)
        {
            anim.SetTrigger("LifeTrigger");
        }

        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
