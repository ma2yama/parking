using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCarFromTop : MonoBehaviour
{
    public GameObject car;
    public float y;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(0, y, 0);
        transform.position = car.transform.position + offset;
    }
}
