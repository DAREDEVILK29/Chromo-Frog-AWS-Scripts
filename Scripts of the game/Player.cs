using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int MoveSpeed = 10;
    private float xInput;
    private float yInput;
    [SerializeField] private Animator Animator;
    [SerializeField] public float colorIndex;
    [SerializeField] private float TongueIndex;
    [SerializeField] public bool isPressed;
    [SerializeField] private bool IsWalking;
    [SerializeField] private bool IsMoving;
    [SerializeField] private bool EggCollided;
    // input
    private PlayerInput playerInput;
 
    private EggScript Egg;

    public float SpriteIndex;
  



    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPressed = false;
        Animator = GetComponentInChildren<Animator>();
        playerInput = new PlayerInput();
       
       


    }

 
    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        Egg = collision.collider.gameObject.GetComponent<EggScript>();

        if (Egg != null)
        {
             EggCollided = true;

        }
    }
    void Update()
    {   
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(xInput) > Mathf.Abs(yInput))
        {
            // Move horizontally, ignore vertical input
            rb.linearVelocity = new Vector2(xInput * MoveSpeed, 0f);
            IsMoving = true;
           
         
        }
        else if(Mathf.Abs(yInput) > Mathf.Abs(xInput))
        {
            // Move vertically, ignore horizontal input
            rb.linearVelocity = new Vector2(0f, yInput * MoveSpeed);
            IsMoving = true;


        }
        else
        {   
            rb.linearVelocity = Vector2.zero;
            IsMoving = false;
        }

        if(IsMoving)
        {
            Animator.SetBool("IsWalking",true);
        }
        else
        {
            Animator.SetBool("IsWalking", false);
        }


        Animator.SetFloat("ColorIndex", colorIndex);
        SpriteIndex = Animator.GetFloat("ColorIndex");
        UpdatePlayerLayer(SpriteIndex);

        if (EggCollided && Egg != null && Input.GetKeyDown(KeyCode.Space))
        {
            EggScript.canPassIndex.Add(Egg.ColorIndex);
            string output = "Collected eggs: ";
            foreach (float index in EggScript.canPassIndex)
            {
                output += index + ", ";
            }
            Debug.Log(output);
            colorIndex = Egg.ColorIndex;
            isPressed = true;
            Animator.SetBool("isPressed", isPressed);
            EggCollided = false;

        }
        else if (!EggCollided && Input.GetKeyUp(KeyCode.Space)&& Egg != null)
        {
            isPressed = false;
            Animator.SetBool("isPressed", isPressed);
            Destroy(Egg.gameObject);

        }



        RotationLogic(xInput, yInput);

      
       
       
    }

    private void Grab()
    {
        isPressed = true;


        if (isPressed == true)
        {
            Animator.SetBool("isPressed", isPressed);
            
        }
        else
        {
            Animator.SetBool("isPressed",false);
        }

        isPressed = false;
    }

    private void stopGrab()
    {
        isPressed=false;

    }

    private void UpdatePlayerLayer(float spriteIndex)
    {
        switch (spriteIndex)
        {
            case 4:
                gameObject.layer = LayerMask.NameToLayer("Layer_Red");
                Animator.SetFloat("TongueIndex", spriteIndex);
                Animator.SetFloat("IdleIndex", spriteIndex);

                break;
            case 1:
                gameObject.layer = LayerMask.NameToLayer("Layer_Blue");
                Animator.SetFloat("TongueIndex", spriteIndex);
                Animator.SetFloat("IdleIndex", spriteIndex);
                break;
            case 2:
                gameObject.layer = LayerMask.NameToLayer("Layer_Orange");
                Animator.SetFloat("TongueIndex", spriteIndex);
                Animator.SetFloat("IdleIndex", spriteIndex);
                break;
            case 3:
                gameObject.layer = LayerMask.NameToLayer("Layer_Pink");
                Animator.SetFloat("TongueIndex", spriteIndex);
                Animator.SetFloat("IdleIndex", spriteIndex);
                break;
            case 5:
                gameObject.layer = LayerMask.NameToLayer("Layer_Yellow");
                Animator.SetFloat("TongueIndex", spriteIndex);
                Animator.SetFloat("IdleIndex", spriteIndex);
                break;
            default:
                gameObject.layer = LayerMask.NameToLayer("Player");
                Animator.SetFloat("TongueIndex", 0);
                Animator.SetFloat("IdleIndex", 0);
                break;
        }
    }
    private void RotationLogic(float x, float y)
    {
        if (xInput > 0)
        {
            rb.rotation = -90f;
        }
        else if (xInput < 0)
        {
            rb.rotation = 90f;
        }


        if (yInput < 0)
        {
            rb.rotation = 180f;
        }
        else if (yInput > 0)
        {
            rb.rotation = 0f;
        }
    }


}
