using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator p1Animator;
    
    private float movementX;
    private float movementY;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] Transform foot1, foot2;
    private bool isJumping;
    private float lastMoveX;


    void Start()
    {
        p1Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = foot1.GetComponent<GroundCheck>().isGrounded || foot2.GetComponent<GroundCheck>().isGrounded;



        if (P1Controller.instance.enabled == true)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            if (moveX == 0 && movementX != 0)
            {
                lastMoveX = movementX;
                p1Animator.SetFloat("LastMoveX", lastMoveX);                
            }

                movementX = moveX;
                
        }
        else movementX = 0;
        movementY = rb.velocity.y;

        if (P1Controller.instance.isJumping)
        {
            isJumping = true;
            p1Animator.SetBool("Grounded", false);
        }

        if (isGrounded && isJumping && rb.velocity.y <= 0.001f)
        {
            P1Controller.instance.isJumping = false;
            p1Animator.SetBool("Grounded", true);
        }
    }

    private void FixedUpdate()
    {
        p1Animator.SetFloat("VelY", movementY);
        p1Animator.SetFloat("MoveX", movementX);
        p1Animator.SetFloat("XMag", Mathf.Abs(movementX));

        
    }

    void StaticRb()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (P1Controller.instance.enabled == false && isGrounded)
        {
            StaticRb();
        }
    }
}
