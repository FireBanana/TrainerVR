using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [HideInInspector]public bool IsActivated;
    public bool IsFinal;
    public Material ActivatedMaterial;
    Material DefaultMaterial;
    MeshRenderer renderer;

    public Rings Controller;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        DefaultMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Car")
            return;

        if (!IsActivated)
            return;

        if (!IsFinal)
            Controller.RingPassed();
        else
            Controller.End();
    }

    public void Deactivate()
    {
        renderer.material = DefaultMaterial;
    }

    public void Activate()
    {
        renderer.material = ActivatedMaterial;
    }
}
