using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPoint : MonoBehaviour
{
    public int force;
    Spring spring;
    void Start()
    {
        spring = GetComponentInParent<Spring>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spring.Launch(other.gameObject, this);
        }
    }
}
