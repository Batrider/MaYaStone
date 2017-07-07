using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float distance;
    public Transform target;
    void Start()
    {
        transform.position = target.transform.position + distance * Vector3.up;
    }
    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
    }
}
