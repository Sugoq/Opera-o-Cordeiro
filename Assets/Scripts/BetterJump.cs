using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    Rigidbody2D rb;

    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpingMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            rb.gravityScale = jumpingMultiplier;
        }
        else rb.gravityScale = 1;
    }
}
