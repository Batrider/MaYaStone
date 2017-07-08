using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingRibbon : MonoBehaviour
{
    public Vector3 force;
    // Use this for initialization
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Rigidbody body = other.GetComponent<Rigidbody>();
            body.AddForce(force, ForceMode.Acceleration);
        }
    }
}
