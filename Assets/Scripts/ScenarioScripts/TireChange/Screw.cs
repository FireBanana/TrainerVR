using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public bool isAvailable;
    public bool IsNew;
    public Tire TireContainer;

    public void Remove()
    {
        isAvailable = false;
        TireContainer.RemoveScrew(transform.parent.gameObject);
    }

    public void Add()
    {
        isAvailable = true;
        TireContainer.AddScrew(transform.parent.gameObject);
    }
}
