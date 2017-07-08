using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("加速度因子")]
    private float accelerFB;
    [SerializeField]
    private float accelerLR;
    [SerializeField]
    private float threshold;
    [SerializeField]
    private float brakeFactor;
    Rigidbody player;
    [SerializeField]
    private float maxSpeed;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (Mathf.Max(Mathf.Abs(player.velocity.y), Mathf.Abs(player.velocity.z)) > maxSpeed)
        {
            return;
        }
        if (Mathf.Abs(Input.acceleration.x) > threshold)
        {
            if (player.velocity.y * Input.acceleration.x > 0)
            {
                player.AddForce(accelerLR * Input.acceleration.x * Vector3.right);
            }
            else
            {
                player.AddForce(brakeFactor * accelerLR * Input.acceleration.x * Vector3.right);
            }
        }
        if (Mathf.Abs(Input.acceleration.y) > threshold)
        {
            if (player.velocity.z * Input.acceleration.y > 0)
            {
                player.AddForce(accelerFB * Input.acceleration.y * Vector3.forward);
            }
            else
            {
                player.AddForce(brakeFactor * accelerFB * Input.acceleration.y * Vector3.forward);
            }
        }
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (player.velocity.y * Input.acceleration.y >= 0)
            {
                player.AddForce(accelerFB * Vector3.forward);
            }
            else
            {
                player.AddForce(brakeFactor * accelerFB * Vector3.forward);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (player.velocity.y * Input.acceleration.y >= 0)
            {
                player.AddForce(accelerFB * Vector3.back);
            }
            else
            {
                player.AddForce(brakeFactor * accelerFB * Vector3.back);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (player.velocity.x * Input.acceleration.x >= 0)
            {
                player.AddForce(accelerLR * Vector3.left);
            }
            else
            {
                player.AddForce(brakeFactor * accelerLR * Vector3.left);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (player.velocity.x * Input.acceleration.x >= 0)
            {
                player.AddForce(accelerLR * Vector3.right);
            }
            else
            {
                player.AddForce(brakeFactor * accelerLR * Vector3.right);
            }
        }
#endif
        Debug.Log(player.velocity);
    }
}
