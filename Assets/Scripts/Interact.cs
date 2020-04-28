using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Usable Interactable;
    
    public void Use(Vector3 localPosition, Vector3 currentPosition, Transform controllerTransform)
    {
        Interactable.Use(localPosition, currentPosition, controllerTransform);
    }

    public void Released()
    {
        Interactable.Released();
    }
}
