using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Menel : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;
    bool locked = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (locked==false && collision.transform.CompareTag("Player"))
        {
            locked = true;
            StartCoroutine(DeathSentence());
        }
    }

    IEnumerator DeathSentence()
    {
        deathParticles.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
