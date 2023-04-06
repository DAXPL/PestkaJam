using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Dzwig : MonoBehaviour
{
    private float speed = 2f;
    Transform transform;
    GameObject klon;
    HingeJoint2D klonhj;
    [SerializeField] GameObject kib;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(kib, new Vector3(-0.02f, 5.31f, 0), Quaternion.identity);
            Debug.Log("cokolwiek");
        }

    }

 


}
