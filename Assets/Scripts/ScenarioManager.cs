using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [HideInInspector] public int TimeAlloted;
    //TODO: Make time UI

    public enum Scenario
    {
        Cones,
        UTurn,
        Parking,
        ChangeTire,
        EngineWater,
        Complete,
        FreeRoam
    }

    public static Scenario CurrentScenario;
    public static bool EnableTimer;
    public GameObject ConeContainer;
    public GameObject CompleteContainer;

    private void Start()
    {
        SetScenario();

        if (EnableTimer)
        {
            //set timer element active
            //start countdown
            //show end screen
        }
    }

    void SetScenario()
    {
        if(CurrentScenario == Scenario.Cones)
        {
            ConeContainer.SetActive(true);
        }
        else if (CurrentScenario == Scenario.ChangeTire)
        {
            //wheel made
        }
        else if (CurrentScenario == Scenario.EngineWater)
        {

        }
        else if (CurrentScenario == Scenario.FreeRoam)
        {

        }
        else if (CurrentScenario == Scenario.Parking)
        {

        }
        else if(CurrentScenario == Scenario.Complete)
        {
            CompleteContainer.SetActive(true);
        }
        else if (CurrentScenario == Scenario.UTurn)
        {

        }
    }
}
