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
            initialGrabLocation = transform.position;
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
            currentInteract.Use(initialGrabLocation, transform.position);
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
        isHandIn = true;
        currentCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        isHandIn = false;
    }
}


