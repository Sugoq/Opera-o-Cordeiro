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
    LayerMask groundLayer;
    private float rayDistance;
    private bool isJumping;


    void Start()
    {
        p1Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rayDistance = P1Controller.instance.rayDistance;
        groundLayer = P1Controller.instance.groundLayer;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = foot1.GetComponent<GroundCheck>().isGrounded || foot2.GetComponent<GroundCheck>().isGrounded;



        if (P1Controller.instance.enabled == true)
        {
            movementX = Input.GetAxisRaw("Horizontal");
        }
        else movementX = 0;

        movementY = rb.velocity.y;

        if (P1Controller.instance.isJumping)
        {
            isJumping = true;
            p1Animator.SetBool("Jump", true);
            p1Animator.SetBool("IsOnGround", false);
        }

        if (movementX > 0)
        {
            p1Animator.SetBool("Walk", true);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (movementX < 0)
        {
            p1Animator.SetBool("Walk", true);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            p1Animator.SetBool("Walk", false);
        }

        if (isGrounded && isJumping && rb.velocity.y <= 0.001f)
        {
            P1Controller.instance.isJumping = false;
            p1Animator.SetBool("Jump", false);
            p1Animator.SetBool("IsOnGround", true);

        }
    }

    private void FixedUpdate()
    {
        
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
