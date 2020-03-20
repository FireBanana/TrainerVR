using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    public virtual void Use(Vector3 startPosition, Vector3 deltaPosition)
    {
        throw new UnityException("Please implement Use method");
    }
}
