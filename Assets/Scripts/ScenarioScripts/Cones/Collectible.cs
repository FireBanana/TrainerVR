using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool HasCollected;
    public MeshRenderer Renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Car")
            return;

        Renderer.enabled = false;
        HasCollected = true;
    }
}
