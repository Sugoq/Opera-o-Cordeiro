using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AnimationHandler : MonoBehaviour
{
    public static P1AnimationHandler instance;
     
    [SerializeField] Animator p1Animator;
    [SerializeField] float idleTime = 0.2f;
    private float lastMovementX;
    private float movementX;
    private float movementY;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] Transform foot1, foot2;
    private bool isJumping;
    private bool isInvokingP2;
    public bool isIdle;
    private void Awake()
    {
        instance = this;

    }
    private void OnDestroy()
    {
        instance = null;
    }

    void Start()
    {
        p1Animator = GetComponent<Animator>();
        print(lastMovementX);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = foot1.GetComponent<GroundCheck>().isGrounded || foot2.GetComponent<GroundCheck>().isGrounded;



        if (P1Controller.instance.enabled == true)
        {
            //p1Animator.SetFloat("LastX", movementX);
            float moveX = Input.GetAxisRaw("Horizontal");
            if ((moveX != lastMovementX) && lastMovementX != 0 && moveX != 0 && !isIdle)
            {
                //lastMovementX = moveX;
                
                p1Animator.SetFloat("LastX", moveX);
                lastMovementX = 0;
            }
            else if (movementX == 0 && moveX == 0)
            {
                p1Animator.SetFloat("LastX", lastMovementX);
            }
            else
            {
                lastMovementX = movementX;
                p1Animator.SetFloat("LastX", lastMovementX);
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

    void KinematicRb()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (P1Controller.instance.enabled == false && isGrounded)
        {
            KinematicRb();
            transform.SetParent(collision.gameObject.transform);
            print(collision.transform);
        }

    }

    public void InvokingP2()
    {
        isInvokingP2 = !isInvokingP2;
        p1Animator.SetBool("Invoking",isInvokingP2);
        
        float f = p1Animator.GetFloat("IdleX");
    }

}
