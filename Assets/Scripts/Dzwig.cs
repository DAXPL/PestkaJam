using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Dzwig : MonoBehaviour
{
    [SerializeField] GameObject kib;
    [SerializeField] private Transform resp;
    [SerializeField] private Rigidbody2D hinge;
    Kible kibelek;

    void Start()
    {
        kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
        if (kibelek)
        {
            kibelek.Odblokuj(false, hinge);
        }
    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && kibelek)
        {
            kibelek.Odblokuj(true);
            kibelek = null;
            StartCoroutine(StawiajKibla());
        }
    }

    IEnumerator StawiajKibla()
    {
        yield return new WaitForSeconds(1);
        kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
        kibelek.Odblokuj(false, hinge);
    }
}
