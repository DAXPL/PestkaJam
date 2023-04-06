using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Kible : MonoBehaviour
{
    private Rigidbody2D rb_kibel;
    private HingeJoint2D hj_kibel;
    private void Start()
    {
        rb_kibel = GetComponent<Rigidbody2D>();
        hj_kibel = GetComponent<HingeJoint2D>();
 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hj_kibel.enabled = false;
        }
    }


}
