using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 20f;
    public float jumpPower = 5f;
    public float horizontalMove = 0f;
    bool duck = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    public int extraJumps = 0;
    int jumpCount = 0;
    bool isGrounded;
    float jumpCoolDown;
    bool jumping = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        

        if (Input.GetButtonDown("Jump")){
            
            animator.SetBool("isJumping", true);
            jumping = true;
            Jump();
        }
        CheckGround();
        if (Input.GetButtonDown("Crouch")){
            duck = true;
        }
        else if (Input.GetButtonUp("Crouch")){
            duck = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, duck, false);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
        
    }
    public void OnDucking(bool iscrouching){
        animator.SetBool("isCrouching", iscrouching);
    
    }

    void Jump(){
        if (isGrounded || jumpCount < extraJumps){
             rb.velocity = new Vector2(rb.velocity.x, jumpPower);
             jumpCount++;
        }
       
    }
    void CheckGround(){
        if (Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer)){
            isGrounded = true;
            jumpCount= 0;
            jumpCoolDown = Time.time + 0.2f;
            animator.SetBool("isFalling", false);
            jumping = false;
        }
        else{
            isGrounded = false;
            if (jumping == false && isGrounded == false)
            {
                animator.SetBool("isFalling", true);
            }
        }
        if(Time.time < jumpCoolDown){
            isGrounded = true;
        }
        
    }
    

    void Start()
    {

    }
}