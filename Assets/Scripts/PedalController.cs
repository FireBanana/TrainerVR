using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalController : MonoBehaviour
{
    public GameObject GasPedal;
    public GameObject BrakePedal;
    public GameObject ClutchPedal;

    [Space]
    public float MaxPushDistance = 1;

    Vector3 InitialRotation_Gas, InitialRotation_Brake, InitialRotation_Clutch;
    [HideInInspector] public Clutch Clutch;
    [HideInInspector] public Gas Gas;

    CarController carController;

    private void Start()
    {
        carController = GetComponent<CarController>();

        InitialRotation_Gas = GasPedal.transform.eulerAngles;
        InitialRotation_Brake = BrakePedal.transform.eulerAngles;
        InitialRotation_Clutch = ClutchPedal.transform.eulerAngles;

        Clutch = new Clutch();
        Gas = new Gas();

        HandEventManager.RightIndexTriggerHeld += (val) => { PressGas(val); };
    }

    public void PressGas(float pushThreshold)
    {        
        GasPedal.transform.eulerAngles = Vector3.Lerp(InitialRotation_Gas, new Vector3(InitialRotation_Gas.x + pushThreshold * MaxPushDistance, InitialRotation_Gas.y, InitialRotation_Gas.z), 0.5f);
        carController.ApplyTorque(pushThreshold);
    }

    public void PressBrake(float pushThreshold)
    {
        BrakePedal.transform.eulerAngles = Vector3.Lerp(InitialRotation_Brake, new Vector3(InitialRotation_Brake.x + pushThreshold * MaxPushDistance, InitialRotation_Brake.y, InitialRotation_Brake.z), 0.5f);
    }

    public void PressClutch(float pushThreshold)
    {
        ClutchPedal.transform.eulerAngles = Vector3.Lerp(InitialRotation_Clutch, new Vector3(InitialRotation_Clutch.x + pushThreshold * MaxPushDistance, InitialRotation_Clutch.y, InitialRotation_Clutch.z), 0.5f);
        Clutch.Push(pushThreshold);
    }
}

public class Clutch : Pedal
{

}

public class Brake : Pedal
{

}

public class Gas : Pedal
{

}
