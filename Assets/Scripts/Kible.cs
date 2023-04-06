using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Kible : MonoBehaviour
{
    [SerializeField] GameObject kib;
    private Rigidbody2D rb_kibel;
    private Transform startPosition;
    private void Start()
    {
        rb_kibel = GetComponent<Rigidbody2D>();
 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb_kibel.bodyType = RigidbodyType2D.Dynamic;
        }

    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Podloga"))
        {
                rb_kibel.bodyType = RigidbodyType2D.Static;
                Instantiate(kib, new Vector3(-0.04f, 9.07f, 0), Quaternion.identity);
        }
    }
}
