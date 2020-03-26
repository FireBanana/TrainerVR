using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Should be on the steering wheel object
public class SteeringWheelController : Usable
{
    public CarController carController;
    public float TurnSensitivity = 10;
    public float MaxTurnAngle = 180;

    Transform parentPivot;

    private void Start()
    {
        parentPivot = transform.parent;
    }

    public void TurnWheel(float turnIncrement)
    {
        var currentRotation = parentPivot.transform.eulerAngles;
        parentPivot.transform.eulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, currentRotation.y, currentRotation.z + turnIncrement), TurnSensitivity);

        carController.Steer(turnIncrement);
    }

    Vector3 lastPosition = Vector3.zero;
    float totalTurn;

    public override void Use(Vector3 startPosition, Vector3 currentPosition)
    {
        if (lastPosition == Vector3.zero)
            lastPosition = currentPosition;

        var to = currentPosition - parentPivot.position;
        var from = lastPosition - parentPivot.position;

        var angle = Vector3.SignedAngle(from, to, parentPivot.forward);
        lastPosition = currentPosition;

        if (Mathf.Abs(totalTurn + angle) >= MaxTurnAngle)
            return;

        totalTurn += angle;

        TurnWheel(angle);
    }

    public override void Released()
    {
        lastPosition = Vector3.zero;
    }
}
