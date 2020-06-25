using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overshoot : MonoBehaviour
{
    public Parking parking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Car")
            return;

        parking.hasOvershot = true;
    }
}
