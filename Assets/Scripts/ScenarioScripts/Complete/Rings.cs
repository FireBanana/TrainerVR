using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    public List<Ring> RingsList;
    public ScenarioManager Manager;
    int counter = 0;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        RingsList[counter].IsActivated = true;
        RingsList[counter].Activate();

        foreach (var ring in RingsList)
            ring.Controller = this;
    }

    public void RingPassed()
    {
        RingsList[counter].IsActivated = false;
        RingsList[counter].Deactivate();
        counter++;
        RingsList[counter].IsActivated = true;
        RingsList[counter].Activate();
    }

    public void End()
    {
        Manager.SetEnding();
    }
}
