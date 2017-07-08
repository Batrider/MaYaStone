using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public List<SpringPoint> points = new List<SpringPoint>();

    public void Launch(GameObject target, SpringPoint point)
    {
        int index = points.FindIndex(x => x == point);
        if (index >= 0)
        {
            if (points.Count > index + 1 && point.force > 0)
            {
                var nextPoint = points[index + 1];
                var dir = Vector3.Normalize(nextPoint.transform.position - point.transform.position);
                Rigidbody body = target.GetComponent<Rigidbody>();
                body.velocity = Vector3.zero;
                body.AddForce((dir + Vector3.up) * point.force);
            }
        }
    }
}
