using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightHand : MonoBehaviour
{
    bool isHandIn, isGripHeld, inUse;
    Collider currentCollider;
    Interact currentInteract;
    Vector3 initialGrabLocation;
    public Transform parentTransform;
    public Transform controllerTransform;

    void Start()
    {
        HandEventManager.RightHandTriggerPressed += GripPressed;
        HandEventManager.RightHandTriggerReleased += GripReleased;
    }

    void GripPressed()
    {
        isGripHeld = true;

        if (isHandIn)
        {
            currentInteract = currentCollider.GetComponent<Interact>();
            //initialGrabLocation = transform.position;
        }
    }

    void GripReleased()
    {
        isGripHeld = false;
    }

    private void Update()
    {
        if (isHandIn && isGripHeld)
        {
            currentInteract.Use(controllerTransform.localPosition, transform.position, parentTransform);
            inUse = true;
        }
        else if (!isGripHeld && isHandIn && inUse)
        {
            inUse = false;
            currentInteract.Released();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "UISelectable")
        {
            var uiSelectable = other.GetComponent<UISelectable>();
            uiSelectable.Select();
            return;
        }

        isHandIn = true;
        currentCollider = other;

        // TESTING - REMOVE BEFORE DEPLOYING
        //GripPressed();
        //
    }

    private void OnTriggerExit(Collider other)
    {
        //TESTING - REMOVE
        //currentInteract.Released();

        if (other.tag == "UISelectable")
        {
            return;
        }

        isHandIn = false;
    }
}


