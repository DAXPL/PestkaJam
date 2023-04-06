using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Kible : MonoBehaviour
{
    public void Odblokuj(bool locked, Rigidbody2D hinge = null)
    {
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<HingeJoint2D>().enabled = !locked;
        GetComponent<HingeJoint2D>().connectedBody = hinge;
    }

}
