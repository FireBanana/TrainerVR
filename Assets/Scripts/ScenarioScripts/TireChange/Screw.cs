using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    public float CurrentSpin;
    public bool isAvailable;
    public Spanner Spanner;

    public void Remove()
    {
        isAvailable = false;
        Spanner.CheckScrews();
        Spanner.IsHooked = false;
    }
}
