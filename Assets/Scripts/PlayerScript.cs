using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public GameObject fighter;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField] private float dealDamage;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private bool duck = false;
    private bool attack = false;
    private bool canDealDamage = false;
    private bool pickUp = false;
    public bool hasItem = false;

    #region PunchRegion
    private PunchingTrigger punchTrig;
    #endregion
    
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        punchTrig = GetComponentInChildren<PunchingTrigger>();
    }

    #region INPUTSYSTEMFUNCTIONS
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    public void OnDuck(InputAction.CallbackContext context)
    {
        duck = context.action.triggered;
    }

    public void OnPickUpItem(InputAction.CallbackContext context)
    {
        pickUp = context.action.triggered;
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        attack = context.action.triggered;
    }
    #endregion
    
    void Update()
    {
        #region MOVEMENT_FUNCTIONING
        float moveX = movementInput.x * movementInput.x;
        animator.SetFloat("Blend", moveX);
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, 0);
        controller.Move(move  * playerSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        

        #endregion

        if (!hasItem && attack)
        {
            animator.SetBool("PunchTrigger", true);
            canDealDamage = true;
            StartCoroutine(PunchBoolSet());
            attack = false;
        }

        if (punchTrig.isHittingEnemy && canDealDamage)
        {
            DealDamage();
        }
    }

    IEnumerator PunchBoolSet()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("PunchTrigger", false);
    }
    
    #region DAMAGE_DEALER_AND_HEALTH

    void DealDamage()
    {
        canDealDamage = false;
        Debug.Log("dealing damage");
    }
    
    #endregion 
}
