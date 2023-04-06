using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;


public class Kible : MonoBehaviour
{
    int ilekibli = 0;
    Dzwig dzwig1;
    bool blokada = false;
   

    public void Odblokuj(bool locked, Dzwig dzwig, Rigidbody2D hinge = null)
    {
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<HingeJoint2D>().enabled = !locked;
        GetComponent<HingeJoint2D>().connectedBody = hinge;
        dzwig1 = dzwig;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kibel") || (collision.gameObject.CompareTag("Podloga") && dzwig1.ilekibelkow==0)) {
            if (!blokada)
            {
                dzwig1.ilekibelkow++;
                blokada = true;
            }
        } else if (collision.gameObject.CompareTag("Podloga") && dzwig1.ilekibelkow != 0)
        {
            SceneManager.LoadScene("MinigraKible");
        }

    }

   
}
