using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackHandle : Usable
{
    Vector3 lastPosition = Vector3.zero;
    Vector3 pos;
    public GameObject Rod;
    bool justPressed;

    private void Start()
    {
        pos = transform.eulerAngles;
    }

    public override void Use(Vector3 localPosition, Vector3 currentPosition, Transform controllerTransform)
    {
        if (!justPressed)
        {
            justPressed = true;
            pos = transform.eulerAngles;
        }

        if (lastPosition == Vector3.zero)
            lastPosition = currentPosition;

        var to = currentPosition - transform.position;
        var from = lastPosition - transform.position;

        var angle = Vector3.SignedAngle(from, to, transform.right);
        lastPosition = currentPosition;

        pos.x += angle;
        transform.eulerAngles = pos;

        var rodPosition = Rod.transform.position;
        rodPosition.y += angle * 0.0005f;
        Rod.transform.position = rodPosition;
    }

    public override void Released()
    {
        lastPosition = Vector3.zero;
        justPressed = false;
    }
}
