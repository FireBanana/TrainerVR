using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint_Cone : MonoBehaviour
{
    public ScenarioManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Car")
            return;

        manager.SetEnding();
    }
}
