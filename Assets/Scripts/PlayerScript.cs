using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    #region VARIABLES
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
    public float knockForcePointer = 2.5f;
    private float knockForcePrivate;
    private Vector3 impact = Vector3.zero;

    [SerializeField] private float damageDealtPointer = 10f;
    private float damageDealtPrivate;
    [SerializeField] private float maxHealth = 100f;
    [HideInInspector] public float currHealth;

    [Header("Item PickUp")] 
    [SerializeField] private Transform slot;
    private bool isEquiped = false;
    public ItemScript itemScript; 
    public bool isPlayerNearItem = false;

    [Header("Effects")] 
    public GameObject bloodEffects;
    
    //timer variables
    bool startTimer = true;
    public float timer = 4f;
    #endregion

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
        knockForcePrivate = knockForcePointer;
        damageDealtPrivate = damageDealtPointer;
        
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
        #region START_TIMER

        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                startTimer = false;
                timer = 4f;
            }
        }
        
        #endregion
        
        #region MOVEMENT_FUNCTIONING

        if (!startTimer)
        {
            float moveX = movementInput.x * movementInput.x;

            animator.SetFloat("Blend", moveX);

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }


            Vector3 move = new Vector3(movementInput.x, 0, 0);

            controller.Move(move * playerSpeed * Time.deltaTime);


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
            playerVelocity.z = 0f;
            controller.Move(playerVelocity * Time.deltaTime);

            if (impact.magnitude > 0.2)
            {
                controller.Move(impact * Time.deltaTime);
            }

            impact.z = 0f;
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }

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
            DealDamage(damageDealtPrivate);
        }
        #endregion

        #region ITEM_MANAGEMENT
        
            if (pickUp)
            {
                if (isEquiped)
                {
                    Dropitem(itemScript);
                }
                else if (!isEquiped && isPlayerNearItem)
                {
                    PickItem(itemScript);
                }

                pickUp = false;
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
            enemyToDamage.AddImpact(enemyToDamage.transform.position * knockForcePrivate);
        }
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Invoke("Die", 1.0f);
        }
    }

    void CreateBloodEffects(Vector3 pos, Quaternion rot)
    {
        Instantiate(bloodEffects, pos, rot);
    }

    void Die()
    {
        if (gameObject.CompareTag("PlayerOne"))
        {
            UIManager.playerTwoWins++;
        }
        else if (gameObject.CompareTag("PlayerTwo"))
        {
            UIManager.playerOneWins++;
        }
        
        Destroy(gameObject);
    }

    #endregion

    #region PHYSICS_FUNCTIONS

    public void AddImpact(Vector3 force)
    {
        var dir = force.normalized;
        dir.y = 0.5f;
        impact += dir.normalized * force.magnitude / mass;
        impact.z = 0.0f;
    }

    #endregion

    #region ITEM_MANAGMENT

    private void PickItem(ItemScript itemScriptTemp)
    {
        isEquiped = true;
        itemScript = itemScriptTemp;

        damageDealtPrivate = itemScriptTemp.damage;
        knockForcePrivate = itemScriptTemp.knockbackForce;

        itemScriptTemp.Rb.isKinematic = true;
        itemScriptTemp.Rb.velocity = Vector3.zero;
        itemScriptTemp.Rb.angularVelocity = Vector3.zero;
        
        itemScriptTemp.transform.SetParent(slot);
        //for some reason the parent is being unset afterwords

        itemScriptTemp.transform.localPosition = Vector3.zero;
        itemScriptTemp.transform.localEulerAngles = Vector3.zero;
    }

    private void Dropitem(ItemScript itemScriptTemp)
    {
        isEquiped = false;
        itemScript = null;

        damageDealtPrivate = damageDealtPointer;
        knockForcePrivate = knockForcePointer;
        
        itemScriptTemp.Rb.isKinematic = false;
        itemScriptTemp.transform.SetParent(null);
        
        itemScriptTemp.Rb.AddForce(itemScriptTemp.transform.forward * 2, ForceMode.VelocityChange);
    }

    #endregion
}
