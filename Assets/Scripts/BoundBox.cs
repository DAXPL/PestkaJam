using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBox : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instace.OnPlayerLost(true);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
