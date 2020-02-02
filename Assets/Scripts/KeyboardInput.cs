using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class KeyboardInput : MonoBehaviour
{
    CarController carController;
    public SteeringWheelController steerController;
    public PedalController pedalController;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    void FixedUpdate()
    {
        steerController.TurnWheel(Input.GetAxis("Horizontal"));

        pedalController.PressGas(Input.GetAxis("Gas"));
        pedalController.PressBrake(Input.GetAxis("Brake"));
        pedalController.PressClutch(Input.GetAxis("Clutch"));
    }
}
