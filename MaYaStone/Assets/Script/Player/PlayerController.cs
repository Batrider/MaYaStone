using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("加速度因子")]
    private float accelerFactor;
    Rigidbody player;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        player.AddForce(accelerFactor * new Vector3(Input.acceleration.x, 0, Input.acceleration.y));
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.UpArrow))
        {
            player.AddForce(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            player.AddForce(Vector3.back);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(Vector3.right);
        }
#endif
    }
}
