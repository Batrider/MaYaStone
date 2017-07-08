using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingRibbon : MonoBehaviour
{
    public Vector3 force;
    public Material material;
    public float Speed = 1;
    public void Awake()
    {
        material = GetComponent<MeshRenderer>().material;

    }

    // Use this for initialization

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody body = other.GetComponent<Rigidbody>();
            body.AddForce(force, ForceMode.Acceleration);
        }
    }

    public void Update()
    {
        material.mainTextureOffset -= Vector2.up * Speed * Time.deltaTime;
    }
}
