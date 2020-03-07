using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider FLCollider, FRCollider, BLCollider, BRCollider;
    public GameObject FLWheel, FRWheel, BLWheel, BRWheel;
    [Space]
    public float MaxAcceleration;
    public int MaxSteerAngle = 45;
    public float SteerSensitivity;
    Engine engine;
    [HideInInspector]public Rigidbody RigidBody;

    private void Start()
    {
        engine = GetComponent<Engine>();
        RigidBody = GetComponent<Rigidbody>();        
    }

    //Reduce CoM


    public void ApplyTorque(float threshold)
    {
        threshold *= -1;

        var torque = MaxAcceleration * engine.GetTorque(Mathf.Abs(RigidBody.velocity.z), threshold);

        //print(torque);

        BLCollider.motorTorque = torque * Time.deltaTime;
        BRCollider.motorTorque = torque * Time.deltaTime;

    }

    public void Steer(float steerInput)
    {
        var val = steerInput * SteerSensitivity;

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
