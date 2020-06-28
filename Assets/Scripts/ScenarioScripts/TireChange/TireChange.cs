using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireChange : MonoBehaviour
{
    public List<MonoBehaviour> Scripts;
    public GameObject RealTire, FakeTire;
    public GameObject ScrewGun;

    private void Awake()
    {
        return;
        foreach(var item in Scripts)
        {
            item.enabled = false;
        }

        RealTire.SetActive(false);
        FakeTire.SetActive(true);
    }
}
