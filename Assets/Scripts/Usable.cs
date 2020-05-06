using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interact))]
public class Usable : MonoBehaviour
{
    public virtual void Use(Vector3 localPosition, Vector3 currentPosiiton, Transform controllerTransform)
    {
        throw new UnityException("Please implement Use method");
    }

    public virtual void Released()
    {
        throw new UnityException("Please implement Released method");
    }
}
