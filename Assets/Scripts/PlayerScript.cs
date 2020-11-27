using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    public bool isDebuggingOn;
    
    public Animator animator;
    public GameObject fighter;

    [Header("Movement")]
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    public float mass = 3.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private bool duck = false;
    private bool attack = false;
    private bool canDealDamage = false;
    private bool pickUp = false;
    private bool hasItem = false;
    
    private PunchingTrigger punchTrig;
    
    //Health and Damage variables
    [Header("Health Components")]
    public PlayerScript enemyToDamage;
    
    //for knockback
    public float knockForce = 2.5f;
    private Vector3 impact = Vector3.zero;

    [SerializeField] private float damageDealt = 10f;
    [SerializeField] private float maxHealth = 100f;
    [HideInInspector] public float currHealth;

    #region INITIALIZATION
    
    private void Awake()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i; j < colliders.Length; j++)
            {
                Physics.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }
    
    private void Start()
    {
        currHealth = maxHealth;
        
        controller = gameObject.GetComponent<CharacterController>();
        punchTrig = GetComponentInChildren<PunchingTrigger>();
    }
    
    #endregion

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

        if (impact.magnitude > 0.2)
        {
            controller.Move(impact * Time.deltaTime);
        }

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        
        #endregion

        #region UPDATE_DAMAGE_DEALING
        if (!hasItem && attack)
        {
            animator.SetBool("PunchTrigger", true);
            canDealDamage = true;
            attack = false;
            StartCoroutine(PunchBoolSet());
        }

        if (punchTrig.isHittingEnemy && canDealDamage)
        {
            DealDamage(damageDealt);
        }
        #endregion
    }

    #region DAMAGE_DEALER_AND_HEALTH

    IEnumerator PunchBoolSet()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("PunchTrigger", false);
    }
    
    void DealDamage(float damageDealt)
    {
        canDealDamage = false;
        punchTrig.isHittingEnemy = false;

        if (enemyToDamage != null)
        {
            enemyToDamage.TakeDamage(damageDealt);
            enemyToDamage.AddImpact(enemyToDamage.transform.position * knockForce);
        }
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    #region PHYSICS_FUNCTIONS

    public void AddImpact(Vector3 force)
    {
        var dir = force.normalized;
        dir.y = 0.5f;
        impact += dir.normalized * force.magnitude / mass;
        Debug.Log("working");
    }

    #endregion
}
