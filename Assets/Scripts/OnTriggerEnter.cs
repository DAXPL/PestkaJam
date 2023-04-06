using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameEvent eventToRaise;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eventToRaise)
        {
            eventToRaise.Raise();
        }
    }
}
