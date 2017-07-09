using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPoint : MonoBehaviour
{
    public int forwardForce;
    public int upForce;
    public AudioClip clip;
    Spring spring;
    void Start()
    {
        spring = GetComponentInParent<Spring>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayClip(clip);
            Animation anim = gameObject.GetComponent<Animation>();
            if (anim != null)
            {
                anim.Play();
            }
            spring.Launch(other.gameObject, this);
        }
    }
}
