using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Vector3 distance;
    public float followSpeed;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.position.x, target.transform.position.y + distance.y, target.transform.position.z + distance.z);
    }
    public void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, target.transform.position.z + distance.z), followSpeed * Time.deltaTime);
        }
    }
}
