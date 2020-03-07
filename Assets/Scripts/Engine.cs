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

    //List<float> gearRatios = new List<float>()
    //{
    //    3.166f,
    //    1.882f,
    //    1.296f,
    //    0.972f,
    //    0.738f,
    //    1
    //};

    List<float> gearSpeeds = new List<float>()
    {
        5.55f,
        11.11f,
        16.66f,
        25f,
        38.8f
    };

    List<int> torques = new List<int>()
    {
        110,
        131,
        148,
        163,
        181
    };

    List<int> rpms = new List<int>()
    {
        947,
        1594,
        2314,
        3086,
        4065
    };

    float finalDriveRatio = 3.69f;

    public GearState CurrentGear = GearState.Neutral;
    List<GearState> CurrentGearArray;

    [HideInInspector] public bool IsEngineOn = false;
    [HideInInspector] public int EngineRPM;

    private void Start()
    {
        pedalController = GetComponent<PedalController>();
        CurrentGearArray = Enum.GetValues(typeof(GearState)).Cast<GearState>().ToList();
    }

    public void ToggleEngine()
    {
        if (IsEngineOn)
        {
            IsEngineOn = false;
            Debug.Log("Engine is off");
        }
        else
        {
            IsEngineOn = true;
            Debug.Log("Engine is on");
        }
    }

    public void ShiftUp(Clutch clutch)
    {
        if (clutch.State.IsPressed)
        {
            CurrentGear = CurrentGearArray.ToList().GetNextGear();
            Debug.Log("Gear changed up");
        }
        else
            Debug.LogError("Gear Contact with shaft!");
    }

    public void ShiftDown(Clutch clutch)
    {
        if (clutch.State.IsPressed)
        {
            CurrentGear = CurrentGearArray.ToList().GetPreviousGear();
            Debug.Log("Gear Changed down");
        }
        else
            Debug.LogError("Gear Contact with shaft!");
    }

    float GetRPM(float velocity, float gasThreshold)
    {
        float maxSpeed = gearSpeeds[0];
        float minSpeed = 0;

        switch (CurrentGear)
        {
            case GearState.Neutral:
                maxSpeed = 0;
                break;
            case GearState.First:
                maxSpeed = gearSpeeds[0];
                minSpeed = 1;
                break;
            case GearState.Second:
                maxSpeed = gearSpeeds[1];
                minSpeed = gearSpeeds[0];
                break;
            case GearState.Third:
                maxSpeed = gearSpeeds[2];
                minSpeed = gearSpeeds[1];
                break;
            case GearState.Fourth:
                maxSpeed = gearSpeeds[3];
                minSpeed = gearSpeeds[2];
                break;
            case GearState.Fifth:
                maxSpeed = gearSpeeds[4];
                minSpeed = gearSpeeds[3];
                break;
            case GearState.Reverse:
                maxSpeed = gearSpeeds[0];
                minSpeed = 1;
                break;
        }

        var speedRatio = (velocity - minSpeed) / (maxSpeed - minSpeed);
        var res = 2000 + ((speedRatio * gasThreshold) * (3500 - 2000));
        EngineRPM = (int)res;
        return res;
    }

    public float GetTorque(float velocity, float gasThreshold)
    {
        //if(velocity < 10 && CurrentGear != GearState.Neutral && CurrentGear != GearState.First && IsEngineOn && !pedalController.Clutch.State.IsPressed)
        //{
        //    ToggleEngine();
        //}

        //if (!IsEngineOn)
        //    return 0;

        if (CurrentGear == GearState.Neutral)
            return 0;

        float RPM = GetRPM(velocity, gasThreshold);
        return Mathf.Lerp(0, 180, (RPM - 2000) / (3500 - 2000)) * -1;
    }
}

public static class EngineExtensions
{
    //Extension
    static int counter = 1;
    public static GearState GetNextGear(this List<GearState> source)
    {
        if (counter + 1 == source.Count())
        {
            return source[counter];
        }

        counter++;
        return source[counter];
    }

    public static GearState GetPreviousGear(this List<GearState> source)
    {
        if (counter - 1 == -1)
        {
            return source[counter];
        }

        counter--;
        return source[counter];
    }
}
