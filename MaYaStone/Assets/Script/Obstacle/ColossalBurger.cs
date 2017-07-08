using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColossalBurger : MonoBehaviour
{
    public ColossalBurgerBuff buff;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buff.hostPlayer = other.gameObject;
            Messenger.Broadcast<BuffBase>(BuffEvent.Add, buff);
            gameObject.SetActive(false);
        }
    }
}
