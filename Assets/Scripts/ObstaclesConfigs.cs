using UnityEngine;

public class ObstaclesConfigs : MonoBehaviour
{
    public float dragSpeed;
    public bool limitDrags;
    public int maxDrags;
    public bool canDrag;
    [HideInInspector] public int dragTimes;

    private void Start()
    {
        canDrag = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("P2") && canDrag == false)
        {
            canDrag = false;
        }

        if (collision.gameObject.CompareTag("P1"))
            canDrag = false;
        
        else return;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P1") && collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
            canDrag = true;
        

        else return;
    }
}
