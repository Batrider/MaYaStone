using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Vector3 distance;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.transform.position.y + distance.y, target.transform.position.z + distance.z);
        }
    }
}
