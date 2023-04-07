using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameEvent eventToRaise;
    [SerializeField] private UnityEvent unityEventToRaise;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(eventToRaise) eventToRaise.Raise();

            unityEventToRaise.Invoke();
        }
    }
}
