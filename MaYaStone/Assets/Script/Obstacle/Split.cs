using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour {

    public SplitBuff buff;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buff.hostPlayer = other.gameObject;
            Messenger.Broadcast<BuffBase>(BuffEvent.Add, buff);
            Destroy(gameObject);
        }
    }
}
