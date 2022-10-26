using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public GameObject car;
    public float radius;
    public float angle;
    public float y;
    private float radian;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Follow car
        radian = (car.transform.eulerAngles.y + angle) * Mathf.PI / 180;
        offset = new Vector3(radius * Mathf.Sin(radian), y, radius * Mathf.Cos(radian));
        transform.SetPositionAndRotation(car.transform.position + offset, car.transform.rotation);
    }
}
