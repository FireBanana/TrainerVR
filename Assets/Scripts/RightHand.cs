using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightHand : MonoBehaviour
{
    bool isHandIn, isGripHeld;
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

        if(isHandIn)
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
            currentInteract.Use(initialGrabLocation, transform.position - initialGrabLocation);
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


