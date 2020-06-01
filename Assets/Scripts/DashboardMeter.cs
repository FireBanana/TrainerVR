using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashboardMeter : MonoBehaviour
{

    public TextMeshProUGUI Speed, RPM;
    Rigidbody rb;

    void Start()
    {
        //rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Speed.text = rb.velocity.z.ToString();
    }
}
