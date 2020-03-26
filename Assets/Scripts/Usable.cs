using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public virtual void Use(Vector3 startPosition, Vector3 currentPosiiton)
    {
        throw new UnityException("Please implement Use method");
    }

    public virtual void Released()
    {
        throw new UnityException("Please implement Released method");
    }
}
