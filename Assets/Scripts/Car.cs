using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [System.Serializable]
    public class AxleInfo
    {
        public Transform visualLeft;
        public Transform visualRight;
        public WheelCollider colliderLeft;
        public WheelCollider colliderRight;
        public bool isMotor; //is this wheel attached to motor?
        public bool isSteering; //does this wheel apply steer angle?
    }

    public List<AxleInfo> axleInfos;    //two wheels per axel
    public float maxMotorTorque;        //maximum torque the motor can apply to wheel
    public float maxSteeringAngle;      //maximum steer angle the wheel can have
    public float maxBrake;

    private void FixedUpdate()
    {
        float brake = 0;
        if (Input.GetButton("Fire1") == true) //joystick A
        {
            brake = maxBrake;
        }

        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo inf in axleInfos)
        {
            if (inf.isMotor)
            {
                inf.colliderLeft.motorTorque = motor;
                inf.colliderRight.motorTorque = motor;
            }
            if (inf.isSteering)
            {
                inf.colliderLeft.steerAngle = steering;
                inf.colliderRight.steerAngle = steering;
            }
            inf.colliderLeft.brakeTorque = brake;
            inf.colliderRight.brakeTorque = brake;

            ApplyLocalPositionToVisuals(inf);
        }
    }
    private void ApplyLocalPositionToVisuals(AxleInfo axle)
    {
        //apply wheelcollider position and rotation to visual wheels
        Vector3 posL;
        Quaternion rotL;
        axle.colliderLeft.GetWorldPose(out posL, out rotL);
        axle.visualLeft.transform.position = posL;
        axle.visualLeft.transform.rotation = rotL;

        Vector3 posR;
        Quaternion rotR;
        axle.colliderRight.GetWorldPose(out posR, out rotR);
        axle.visualRight.transform.position = posR;
        axle.visualRight.transform.rotation = rotR;
    }
}
