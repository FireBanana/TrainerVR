using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : Usable
{
    public GameObject GripObject;
    public bool IsMovable;
    public bool IsUsed;
    int ScrewsRemoved;
    int ScrewsAdded;
    public TireChange TireCh;

    public void RemoveScrew(GameObject screw)
    {
        screw.GetComponent<MeshRenderer>().enabled = false;
        ScrewsRemoved++;

        if(ScrewsRemoved == 4)
        {
            IsMovable = true;
        }
    }

    public void AddScrew(GameObject screw)
    {
        screw.GetComponent<MeshRenderer>().enabled = true;
        ScrewsAdded++;

        if(ScrewsAdded == 4)
        {
            TireCh.End();
        }
    }

    public override void Use(Vector3 localPosition, Vector3 currentPosiiton, Transform controllerTransform)
    {
        if (!IsMovable)
            return;

        transform.SetParent(GripObject.transform);
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public override void Released()
    {
        if (!IsMovable)
            return;

        transform.parent = null;
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
