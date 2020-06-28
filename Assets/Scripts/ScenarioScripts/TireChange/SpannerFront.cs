using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpannerFront : MonoBehaviour
{
    public Spanner Spanner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Screw")
            return;

        var screw = other.GetComponent<Screw>();

        if (!screw.isAvailable)
            return;

        Spanner.transform.position = other.transform.position;
        Spanner.transform.eulerAngles = new Vector3(0, -40, 0);
        Spanner.Hook(screw);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Screw")
            return;

        var screw = other.GetComponent<Screw>();

        if (!screw.isAvailable)
            return;
    }
}
