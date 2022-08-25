using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;

public class ObstaclesConfigs : MonoBehaviour
{
    public float dragSpeed;
    public bool limitDrags;
    public int maxDrags;

    [HideInInspector] public bool isBeingDragged;
    [PropertySpace(SpaceBefore = 5)]

    public bool canDrag;
    public bool dragOnlyX;
    public bool dragOnlyY;

    [PropertySpace(SpaceBefore = 5)]
    
    [InfoBox("Check this if you want the object to move by itself")]
    public bool movingObject;
    public Vector2 finalPosition;
    public float startMoveDelay;
    [InfoBox("How long does it take to move to the final position?")]
    public float movingTime;
    



    [HideInInspector] public int dragTimes;

    private void Start()
    {
        canDrag = !movingObject;
        if (movingObject) StartCoroutine(MovementRoutine(startMoveDelay));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("P2") && canDrag == false)
        {
            canDrag = false;
        }

        if (collision.gameObject.CompareTag("P1"))
        {
            canDrag = false;                   

        }

        else return;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P1") && collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
            canDrag = true;

        else return;

    }

    IEnumerator MovementRoutine(float moveDelay)
    {
        yield return new WaitForSeconds(moveDelay);
        Vector3 startPos = transform.position;
        for (float t = 0; t < 1; t += Time.deltaTime / movingTime)
        {
            transform.position = Vector3.Lerp(startPos, finalPosition, t );
            yield return null;
        }
        transform.position = finalPosition;
        yield return new WaitForSeconds(moveDelay);
        
        for (float t = 0; t < 1; t += Time.deltaTime / movingTime)
        {
            transform.position = Vector2.Lerp(finalPosition, startPos, t );
            yield return null;
        }
        transform.position = startPos;
        StartCoroutine(MovementRoutine(startMoveDelay));
    }
}
