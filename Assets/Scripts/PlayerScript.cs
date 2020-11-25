using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    private GameObject fighter;

    private void Start()
    {
        fighter = gameObject;
        animator.Play("Idle");
    }
}
