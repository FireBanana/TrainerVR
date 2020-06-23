using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static CarController Instance;
    public WheelCollider FLCollider, FRCollider, BLCollider, BRCollider;
    public GameObject FLWheel, FRWheel, BLWheel, BRWheel;
    [Space]
    public float SteerSensitivity;
    Engine engine;
    [HideInInspector]public Rigidbody rigidBody;
    float steerIncrement;

    private void Start()
    {
        Instance = this;
        engine = GetComponent<Engine>();
        rigidBody = GetComponent<Rigidbody>();

        HandEventManager.LeftIndexTriggerHeld += (val) => {
            BLCollider.brakeTorque = Mathf.Lerp(0, 6000, val);
            BRCollider.brakeTorque = Mathf.Lerp(0, 6000, val);
        };
    }

    public void ApplyTorque(float threshold)
    {
        var torque = engine.GetAcceleration(transform.InverseTransformDirection(rigidBody.velocity).z, threshold) * -1;

        BLCollider.motorTorque = torque * Time.deltaTime;
        BRCollider.motorTorque = torque * Time.deltaTime;

    }

    public void Steer(float steerInc)
    {
        steerIncrement += steerInc;

        var val = steerIncrement * SteerSensitivity;

        FLCollider.steerAngle = Mathf.Lerp(FLCollider.steerAngle, val, 0.5f);
        FRCollider.steerAngle = Mathf.Lerp(FLCollider.steerAngle, val, 0.5f);
    }

    void AnimateWheels(GameObject wheel, WheelCollider collider)
    {
        Quaternion rot;
        Vector3 pos;

        collider.GetWorldPose(out pos, out rot);

        wheel.transform.SetPositionAndRotation(pos, rot);
    }

    private void Update()
    {
        AnimateWheels(FLWheel, FLCollider);
        AnimateWheels(FRWheel, FRCollider);
        AnimateWheels(BLWheel, BLCollider);
        AnimateWheels(BRWheel, BRCollider);
    }
}
