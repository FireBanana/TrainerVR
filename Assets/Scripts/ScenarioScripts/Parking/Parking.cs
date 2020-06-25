using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking : MonoBehaviour
{
    Vector3 InitialPostion = new Vector3(25.596f, 1.13f, -15.447f);
    Vector3 InitialRotation = new Vector3(0, -221.444f, 0);
    public ScenarioManager manager;
    public GameObject Car;

    [HideInInspector] public bool hasOvershot;

    private void Awake()
    {
        Car.transform.position = InitialPostion;
        Car.transform.eulerAngles = InitialRotation;
    }

    public void End()
    {
        manager.SetEnding();
    }
}
