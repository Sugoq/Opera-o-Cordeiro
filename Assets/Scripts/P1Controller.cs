using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public static P1Controller instance;
    
    [SerializeField] Transform playerFoot1, playerFoot2;
    [SerializeField] GameObject invokeCircle;
    Rigidbody2D rb;
    public Vector2 invokeOffset;
    
    public int maxSwitchTimes;
    
    public float speed;
    public float gravityIncrease;
    public float jumpForce = 0;
    public float rayDistance;
    public bool isGrounded;
    public bool isJumping;    
    private float movement;
    private int switchTimes;
    
    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -9.81f);
        Physics2D.gravity *= gravityIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = playerFoot1.GetComponent<GroundCheck>().isGrounded || playerFoot2.GetComponent<GroundCheck>().isGrounded;

        movement = Input.GetAxisRaw("Horizontal");
              
        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            if (switchTimes >= maxSwitchTimes) return;
            switchTimes++;
            movement = 0;
            InvokeP2();
            SwitchCharacter.instance.Switch();
            rb.velocity = new Vector2(movement, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded && rb.velocity.y < 1)
            {
                isJumping = true;
                Jump();
                AudioManager.instance.Play("Jump");
            }
        }       
    }

    public void InvokeP2()
    {
        Vector2 spawnPos = (Vector2)transform.position + invokeOffset;
        Instantiate(invokeCircle, spawnPos, Quaternion.identity);
    }

    public void ChangeBodyType()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.parent = null;
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
