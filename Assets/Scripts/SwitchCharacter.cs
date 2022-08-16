using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public static SwitchCharacter instance;

    public bool isP1Turn;
    public GameObject p1;

    private void Awake()
    {
        isP1Turn = true;
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void Switch()
    {
        if (isP1Turn)
        {
            p1.GetComponent<P1Controller>().enabled = false;
            isP1Turn = false;
            P1AnimationHandler.instance.InvokingP2();
        }
        else
        {
            P1AnimationHandler.instance.InvokingP2();
            p1.GetComponent<P1Controller>().enabled = true;
            p1.GetComponent<P1Controller>().ChangeBodyType();
            isP1Turn = true;
        }
    }
}
