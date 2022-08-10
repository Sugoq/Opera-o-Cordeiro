using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Colidindo");
        isGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}

