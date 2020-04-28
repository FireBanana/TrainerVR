using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugHandler : MonoBehaviour
{
    Text label;
    public static DebugHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {        
        //var txt = DebugUIBuilder.instance.AddLabel("mssg");
        //label = txt.GetComponent<Text>();
    }

    public void Log(string message)
    {
        label.text += message;
    }

    private void Update()
    {
        //DebugUIBuilder.instance.Show();
    }
}
