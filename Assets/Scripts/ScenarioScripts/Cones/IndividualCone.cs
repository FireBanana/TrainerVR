using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualCone : MonoBehaviour
{
    public bool HasCollided;
    public int Hits;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Car")
            return;

        if (!HasCollided)
            HasCollided = true;

        Hits++;
    }
}
