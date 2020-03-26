using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Usable Interactable;
    
    public void Use(Vector3 startPosition, Vector3 currentPosition)
    {
        Interactable.Use(startPosition, currentPosition);
    }

    public void Released()
    {
        Interactable.Released();
    }
}
