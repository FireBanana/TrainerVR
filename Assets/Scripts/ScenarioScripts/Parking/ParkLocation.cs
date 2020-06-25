using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkLocation : MonoBehaviour
{
    public Parking manager;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Car")
            return;

        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Car")
            return;

        StartCoroutine(HoldParking());
    }

    IEnumerator HoldParking()
    {
        yield return new WaitForSeconds(4);
        manager.End();
    }
}
