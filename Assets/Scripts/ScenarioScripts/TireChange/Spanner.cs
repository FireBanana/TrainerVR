using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanner : Usable
{
    [HideInInspector] public bool IsHooked;
    [HideInInspector] public Screw CurrentScrew;
    public List<Screw> ScrewList;
    public GameObject GripObject;

    public override void Use(Vector3 localPosition, Vector3 currentPosiiton, Transform controllerTransform)
    {
        if (IsHooked)
            return;

        transform.SetParent(GripObject.transform);
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public override void Released()
    {
        if (IsHooked)
            return;

        transform.parent = null;
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    public void CheckScrews()
    {
        foreach(var screw in ScrewList)
        {
            if (screw.isAvailable)
                return;
        }

        ScrewList[0].transform.parent.gameObject.SetActive(false);
    }

    public void Hook(Screw screw)
    {
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        IsHooked = true;
        CurrentScrew = screw;
        transform.SetParent(null);
    }
}
