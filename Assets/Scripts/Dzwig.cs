using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Dzwig : MonoBehaviour
{
    [SerializeField] GameObject kib;
    [SerializeField] private Transform resp;
    [SerializeField] private Rigidbody2D hinge;
    [SerializeField] private BoxCollider2D kibelekcollider;
    Kible kibelek;
    public int ilekibelkow = 0;
    [SerializeField] private TextMeshProUGUI punkty;
    [SerializeField] private TextMeshProUGUI wygrana;

    void Start()
    {
        kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
        if (kibelek)
        {
            kibelek.Odblokuj(false, this, hinge);
        }
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && kibelek && ilekibelkow < 4)
        {
            kibelek.Odblokuj(true, this);
            kibelek = null;
            StartCoroutine(StawiajKibla());
        }
        punkty.text = "Punkty: " + ilekibelkow;
        if(ilekibelkow == 4)
        {
            wygrana.text = "WYGRALES";
            StartCoroutine(Wygrana());
        }
    }

    IEnumerator StawiajKibla()
    {
            yield return new WaitForSeconds(1);
            kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
            kibelek.Odblokuj(false, this, hinge);
    }

    IEnumerator Wygrana()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");
    }

}
