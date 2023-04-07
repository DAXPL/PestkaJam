using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AngleTester : MonoBehaviour
{
    public float angle;
    public Transform test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //angle = Vector2.SignedAngle(transform.position, test.position);
        angle = Mathf.Atan2(test.position.y - transform.position.y, test.position.x - transform.position.x);
    }
}
