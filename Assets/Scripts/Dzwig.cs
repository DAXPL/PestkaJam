using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
    [SerializeField] private UnityEvent winEvent;
    bool unlocked = false;

    public void UnlockMinigame(bool unlockGame)
    {
        unlocked = unlockGame;
        if(unlocked)
        {
            punkty.text = "Press space to drop!";
        }
    }
    void Start()
    {
        kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
        if (kibelek)
        {
            kibelek.Odblokuj(false, this, hinge);
        }
        punkty.text = "Stack three toilets!";
    }

    private void Update()
    {
        if (!unlocked) return;
        if(ilekibelkow<=0) punkty.text = "Press space to drop!";
        else punkty.text = "Points: " + ilekibelkow;

        if (ilekibelkow >= 3)
        {
            punkty.text = "";
            wygrana.text = "WIN!";
            winEvent.Invoke();
        }
    }

    public void HandleKibelInput(InputAction.CallbackContext context)
    {
        if (!unlocked) return;
        if (kibelek && ilekibelkow < 3)
        {
            kibelek.Odblokuj(true, this);
            kibelek = null;
            StartCoroutine(StawiajKibla());
        }
    }

    IEnumerator StawiajKibla()
    {
            yield return new WaitForSeconds(1);
            kibelek = Instantiate(kib, resp.position, Quaternion.identity).GetComponent<Kible>();
            kibelek.Odblokuj(false, this, hinge);
    }

}
