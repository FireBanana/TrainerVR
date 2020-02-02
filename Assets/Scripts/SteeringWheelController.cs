using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should be on the steering wheel object
public class SteeringWheelController : MonoBehaviour
{
    GameObject SteeringWheel;
    public CarController carController;
    public float TurnSensitivity = 10;
    public float MaxTurnAngle = 100;

    private void Start()
    {
        SteeringWheel = this.gameObject;
    }

    public void TurnWheel(float turnThreshold)
    {
        var currentRotation = SteeringWheel.transform.eulerAngles;
        SteeringWheel.transform.eulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, currentRotation.y, turnThreshold * MaxTurnAngle), TurnSensitivity);

        carController.Steer(turnThreshold);
    }
}
