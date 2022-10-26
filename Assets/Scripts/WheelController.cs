using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    public Transform wheelFLTrans;
    public Transform wheelFRTrans;
    public Transform wheelBLTrans;
    public Transform wheelBRTrans;

    float maxMotorTorque = 400;
    float maxSteeringAngle = 45;
    float downforce = 100;

    float steering = 0.0f;
    float motor = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //wheelcollider の回転速度に合わせてタイヤモデルを回転させる
        wheelFLTrans.Rotate(-wheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheelFRTrans.Rotate(wheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheelBLTrans.Rotate(-wheelBL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        wheelBRTrans.Rotate(wheelBR.rpm / 60 * 360 * Time.deltaTime, 0, 0);

        //wheelcolliderの角度に合わせてタイヤモデルを回転する
        wheelFLTrans.localEulerAngles = new Vector3(wheelFLTrans.localEulerAngles.x, 180 + wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z, wheelFLTrans.localEulerAngles.z);
        wheelFRTrans.localEulerAngles = new Vector3(wheelFRTrans.localEulerAngles.x, wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z, wheelFRTrans.localEulerAngles.z);
    }

    public void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering += Time.deltaTime * 15 * Input.GetAxis("Horizontal");
        if (steering > maxSteeringAngle) {
            steering = maxSteeringAngle;
        } else if (steering < -maxSteeringAngle) {
            steering = maxSteeringAngle;
        }

        wheelFL.steerAngle = steering;
        wheelFR.steerAngle = steering;

        wheelBL.motorTorque = motor;
        wheelBR.motorTorque = motor;

        wheelBL.attachedRigidbody.AddForce(-transform.up * downforce * wheelBL.attachedRigidbody.velocity.magnitude);
        wheelBR.attachedRigidbody.AddForce(-transform.up * downforce * wheelBR.attachedRigidbody.velocity.magnitude);
        wheelFL.attachedRigidbody.AddForce(-transform.up * downforce * wheelFL.attachedRigidbody.velocity.magnitude);
        wheelFR.attachedRigidbody.AddForce(-transform.up * downforce * wheelFR.attachedRigidbody.velocity.magnitude);
    }
}
