using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandEventManager : MonoBehaviour
{
    public static HandEventManager Instance;

    public delegate void ButtonEvent();
    public delegate void ValuedButtonEvent(float val);

    public static event ButtonEvent RightHandTriggerPressed, LeftHandTriggerPressed;
    public static event ButtonEvent RightHandTriggerReleased, LeftHandTriggerReleased;
    //public static event ButtonEvent RightIndexTriggerPressed, RightIndexTriggerReleased;

    public static event ValuedButtonEvent RightIndexTriggerHeld;

    public static event ButtonEvent AButtonPressed;
    public static event ButtonEvent BButtonPressed;

    bool hand_trigger_rightPressed, hand_trigger_leftPressed;
    bool index_trigger_rightPressed;

    bool a_button_pressed, b_button_pressed;

    float threshold = 0.1f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //StartCoroutine(Tester());
    }

    IEnumerator Tester()
    {
        while (true)
        {
            var hand_trigger_valR = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
            print(hand_trigger_valR);
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {

        var hand_trigger_valR = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        var hand_trigger_valL = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        var index_trigger_valR = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        //Button 1 = A, Button 2 = B
        ExecuteButton(ref a_button_pressed, OVRInput.Get(OVRInput.Button.One), AButtonPressed);
        ExecuteButton(ref b_button_pressed, OVRInput.Get(OVRInput.Button.Two), BButtonPressed);

        ExecuteTrigger(hand_trigger_valR, ref hand_trigger_rightPressed, RightHandTriggerPressed, RightHandTriggerReleased);
        ExecuteTrigger(hand_trigger_valL, ref hand_trigger_leftPressed, LeftHandTriggerPressed, LeftHandTriggerReleased);
        ExecuteTriggerWithHeld(index_trigger_valR, ref index_trigger_rightPressed, RightIndexTriggerHeld);
    }

    void ExecuteButton(ref bool previousState, bool currentState, ButtonEvent buttonPressed)
    {

        if (previousState == currentState)
            return;

        if (previousState == true)
        {
            
        }
        else
        {
            buttonPressed.Invoke();
        }

        previousState = currentState;
    }

    void ExecuteTrigger(float value, ref bool pressed, ButtonEvent buttonPressed, ButtonEvent buttonReleased)
    {
        if (value > threshold || value < -threshold)
        {
            if (!pressed)
            {
                pressed = true;
                buttonPressed.Invoke();
            }
        }
        else
        {
            if (pressed)
            {
                pressed = false;
                buttonReleased.Invoke();
            }
        }
    }
    void ExecuteTriggerWithHeld(float value, ref bool pressed, ValuedButtonEvent buttonHeld)
    {
        if (value > threshold || value < -threshold)
        {
            if (!pressed)
            {
                pressed = true;
                //buttonPressed.Invoke();
            }

            buttonHeld(value);
        }
        else
        {
            if (pressed)
            {
                pressed = false;
                //buttonReleased.Invoke();
            }
        }
    }
}
