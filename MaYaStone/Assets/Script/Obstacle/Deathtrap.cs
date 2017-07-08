using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathtrap : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Messenger.Broadcast(PlayerEvent.Dead);
        }
    }
}
