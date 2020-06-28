using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpannerHandle : Usable
    {
    Vector3 lastPosition = Vector3.zero;
    Vector3 pos;
    public Spanner Spanner;
    bool justPressed;

    private void Start()
    {
        pos = transform.parent.parent.eulerAngles;
    }

    public override void Use(Vector3 localPosition, Vector3 currentPosition, Transform controllerTransform)
    {
        if (!Spanner.IsHooked)
            return;

        if (!justPressed)
        {
            justPressed = true;
            pos = transform.parent.parent.eulerAngles;
        }

        if (lastPosition == Vector3.zero)
            lastPosition = currentPosition;

        var to = currentPosition - transform.parent.position;
        var from = lastPosition - transform.parent.position;

        var angle = Vector3.SignedAngle(from, to, transform.parent.parent.forward);
        lastPosition = currentPosition;

        pos.z += angle;
        transform.parent.parent.eulerAngles = pos;

        Spanner.CurrentScrew.CurrentSpin += angle;

        if(Spanner.CurrentScrew.CurrentSpin > 360)
        {
            Spanner.CurrentScrew.Remove();
        }

        ConsoleLogger.Instance.Log(Spanner.CurrentScrew.CurrentSpin);
    }

    public override void Released()
    {
        if (!Spanner.IsHooked)
            return;

        lastPosition = Vector3.zero;
        justPressed = false;
    }
}

