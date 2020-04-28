using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeftHand : MonoBehaviour
{
    bool isHandIn, isGripHeld;
    Collider currentCollider;
    Interact currentInteract;
    Vector3 initialGrabLocation;

    void Start()
    {
        HandEventManager.LeftHandTriggerPressed += GripPressed;
        HandEventManager.LeftHandTriggerReleased += GripReleased;
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
            currentInteract.Use(transform.parent.localPosition, transform.position, transform);
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
