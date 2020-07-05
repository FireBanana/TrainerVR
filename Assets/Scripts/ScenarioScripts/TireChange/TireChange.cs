using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireChange : MonoBehaviour
{
    public List<MonoBehaviour> Scripts;
    public GameObject RealTire, FakeTire;
    public GameObject TireHolder;

    private void Awake()
    {
        foreach(var item in Scripts)
        {
            item.enabled = false;
        }

        RealTire.SetActive(false);
        FakeTire.SetActive(true);

        var InitialTire = FakeTire.GetComponent<Tire>();
        InitialTire.transform.SetParent(TireHolder.transform);
    }

    public void End()
    {

    }

    
}
