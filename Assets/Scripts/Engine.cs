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
        new float[]{0, 6000},
        new float[]{6000, 12000},
        new float[]{12000, 18000},
        new float[]{18000, 24000},
        new float[]{24000, 30000},
    };

    [HideInInspector] public GearState CurrentGear = GearState.First;
    public int acceleration;

    private void Start()
    {
        HandEventManager.AButtonPressed += ShiftDown;
        HandEventManager.BButtonPressed += ShiftUp;
    }

    public void ShiftUp()
    {
        var currentGear = GetGear();

        if (currentGear == 5)
            return;

        ChangeGear(currentGear + 1);

        print("Current gear: " + GetGear());
    }

    public void ShiftDown()
    {
        var currentGear = GetGear();

        if (currentGear == -1)
            return;

        ChangeGear(currentGear - 1);

        print("Current gear: " + GetGear());
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


        if (CurrentGear == GearState.Neutral)
        {
            return 0;
        }

        if(CurrentGear == GearState.Reverse)
        {
            return Mathf.Lerp(0, -6000, gearThreshold);
        }

        var speedFrame = gearTorqueMultipliers[GetGear() - 1];

        return Mathf.Lerp(0, speedFrame[1], gearThreshold);

        //
        //float currentAcceleration;

        //if (currentSpeed < speedFrame[0])
        //{
        //    currentAcceleration = Mathf.Lerp(0, 1, currentSpeed / speedFrame[0]);
        //}
        //else
        //{
        //    currentAcceleration = Mathf.Lerp(1, 0, currentSpeed / speedFrame[1]);
        //}

        //if (currentAcceleration < 0.2f)
        //    currentAcceleration = 0.2f;

        //return currentAcceleration * gearThreshold * acceleration;
    }
}
