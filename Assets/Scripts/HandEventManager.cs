using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEventManager : MonoBehaviour
{

    public delegate void ButtonEvent();

    public static event ButtonEvent RightHandTriggerPressed, LeftHandTriggerPressed;
    public static event ButtonEvent RightHandTriggerReleased, LeftHandTriggerReleased;
    bool rightPressed, leftPressed;
    float threshold = 0.2f;

    void Update()
    {
        //Right Handle Button
        var valR = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        //Left Handle Button
        var valL = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);

        if(valR > threshold || valR < -threshold)
        {
            if(!rightPressed)
            {
                rightPressed = true;
                RightHandTriggerPressed.Invoke();
            }
        }
        else
        {
            if(rightPressed)
            {
                rightPressed = false;
                RightHandTriggerReleased.Invoke();
            }
        }

        if (valL > threshold || valL < -threshold)
        {
            if (!leftPressed)
            {
                leftPressed = true;
                LeftHandTriggerPressed.Invoke();
            }
        }
        else
        {
            if (leftPressed)
            {
                leftPressed = false;
                LeftHandTriggerReleased.Invoke();
            }
        }
    }
}
