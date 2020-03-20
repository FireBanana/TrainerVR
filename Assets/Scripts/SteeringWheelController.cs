using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Should be on the steering wheel object
public class SteeringWheelController : Usable
{
    public CarController carController;
    public float TurnSensitivity = 10;
    public float MaxTurnAngle = 100;

    Transform parentPivot;

    private void Start()
    {
        parentPivot = transform.parent;
    }

    public void TurnWheel(float turnIncrement)
    {
        var currentRotation = parentPivot.transform.eulerAngles;
        parentPivot.transform.eulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, currentRotation.y, currentRotation.z + turnIncrement /** MaxTurnAngle*/), TurnSensitivity);

        carController.Steer(turnIncrement);
    }

    Vector3 lastPosition;

    public override void Use(Vector3 startPosition, Vector3 deltaPosition)
    {
        if (lastPosition == null)
            lastPosition = deltaPosition;

        var angle = Vector3.Angle(lastPosition, deltaPosition);

        TurnWheel(angle);
        lastPosition = deltaPosition;
    }
}
