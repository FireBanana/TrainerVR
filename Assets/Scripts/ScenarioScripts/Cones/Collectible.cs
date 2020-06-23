using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool HasCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Car")
            return;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        HasCollected = true;
    }
}
