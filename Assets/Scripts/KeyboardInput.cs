using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class KeyboardInput : MonoBehaviour
{
    CarController carController;
    public SteeringWheelController steerController;
    public PedalController pedalController;
    public Engine engine;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            engine.ShiftDown();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            engine.ShiftUp();
        }
    }

    void FixedUpdate()
    {
        steerController.TurnWheel(Input.GetAxis("Horizontal"));

        pedalController.PressGas(Input.GetAxis("Gas"));
        pedalController.PressBrake(Input.GetAxis("Brake"));
        pedalController.PressClutch(Input.GetAxis("Clutch"));

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //Toggle engine
        }        
    }
}
