using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using static Engine;

public class Engine : MonoBehaviour
{
    [SerializeField] GameObject gearLever;
    PedalController pedalController;

    public enum GearState
    {
        Reverse,
        Neutral,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
    }

    List<float[]> gearTorqueMultipliers = new List<float[]>()
    {
        new float[]{0, 5.55f},
        new float[]{5.55f, 12.5f},
        new float[]{12.5f, 20.93f},
        new float[]{20.93f, 25f},
        new float[]{25f, 36.1f},
    };

    [HideInInspector] public GearState CurrentGear = GearState.First;
    public int acceleration;

    public void ShiftUp()
    {
        var currentGear = GetGear();

        if (currentGear == 5)
            return;

        ChangeGear(currentGear + 1);
    }

    public void ShiftDown()
    {
        var currentGear = GetGear();

        if (currentGear == -1)
            return;

        ChangeGear(currentGear - 1);
    }

    int GetGear()
    {
        switch (CurrentGear)
        {
            case GearState.Reverse:
                return -1;
            case GearState.Neutral:
                return 0;
            case GearState.First:
                return 1;
            case GearState.Second:
                return 2;
            case GearState.Third:
                return 3;
            case GearState.Fourth:
                return 4;
            case GearState.Fifth:
                return 5;
        }

        return 0;
    }

    void ChangeGear(int gear)
    {
        switch (gear)
        {
            case -1:
                CurrentGear = GearState.Reverse;
                break;
            case 0:
                CurrentGear = GearState.Neutral;
                break;
            case 1:
                CurrentGear = GearState.First;
                break;
            case 2:
                CurrentGear = GearState.Second;
                break;
            case 3:
                CurrentGear = GearState.Third;
                break;
            case 4:
                CurrentGear = GearState.Fourth;
                break;
            case 5:
                CurrentGear = GearState.Fifth;
                break;
        }
    }

    public float GetAcceleration(float currentSpeed, float gearThreshold)
    {
        //check if accelerator pressed


        if (CurrentGear == GearState.Reverse || CurrentGear == GearState.Neutral)
        {
            //Reverse stuff here
            return 0;
        }

        var speedFrame = gearTorqueMultipliers[GetGear() - 1];
        float currentAcceleration;

        if (currentSpeed < speedFrame[0])
        {
            currentAcceleration = Mathf.Lerp(0, 1, currentSpeed / speedFrame[0]);
        }
        else
        {
            currentAcceleration = Mathf.Lerp(1, 0, currentSpeed / speedFrame[1]);
        }

        //REMOVE THIS
        UI.Instance.speed.text = currentSpeed.ToString("0.0");
        //print(currentAcceleration);

        if (currentAcceleration < 0.2f)
            currentAcceleration = 0.2f;

        return currentAcceleration * gearThreshold * acceleration;
    }
}
