using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class ControllerInput : MonoBehaviour
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

    }

    void FixedUpdate()
    {
        //steerController.TurnWheel(Input.GetAxis("Horizontal"));

        //pedalController.PressGas(Input.GetAxis("Gas"));
        
        //pedalController.PressBrake(Input.GetAxis("Brake"));
        //pedalController.PressClutch(Input.GetAxis("Clutch"));

        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    //Toggle engine
        //}        
    }

}
