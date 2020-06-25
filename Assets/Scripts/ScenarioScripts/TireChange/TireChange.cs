using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireChange : MonoBehaviour
{
    public List<MonoBehaviour> Scripts;

    private void Awake()
    {
        foreach(var item in Scripts)
        {
            item.enabled = false;
        }
    }
}
