using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Engine _engine;
    public PedalController pedalController;
    public CarController carController;
    public static UI Instance;

    public Text engine, gear, accelerator, rpm, speed;

    private void Start()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        //engine.text = _engine.IsEngineOn.ToString();
        gear.text = _engine.CurrentGear.ToString();
        accelerator.text = pedalController.Gas.State.PushValue.ToString();
        //speed.text = carController.rigidBody.velocity.z.ToString("0.0");
        //rpm.text = _engine.EngineRPM.ToString();
    }
}
