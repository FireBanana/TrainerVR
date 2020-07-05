using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewGun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Screw")
            return;

        var screw = other.GetComponent<Screw>();

        if (screw.IsNew)
        {
            if (screw.isAvailable)
                return;

            screw.Add();
        }
        else
        {
            if (!screw.isAvailable)
                return;

            screw.Remove();
        }        
    }
}
