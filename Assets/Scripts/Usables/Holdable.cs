using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Usable
{
    public GameObject GripObject;

    public override void Use(Vector3 localPosition, Vector3 currentPosiiton, Transform controllerTransform)
    {
        transform.SetParent(GripObject.transform);
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public override void Released()
    {
        transform.parent = null;
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
