using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var tire = other.GetComponent<Tire>();
        if (tire == null) return;
        if (tire.IsUsed) return;

        tire.transform.SetParent(transform);

        tire.transform.position = transform.position;
        tire.transform.rotation = transform.rotation;

        tire.IsUsed = true;
        tire.IsMovable = false;
    }
}
