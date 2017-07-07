using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public enum PlayerState
    {
        Normal,//
        God,//无敌
        Dead,//死亡
    }
    [SerializeField]
    private float deadLine = -12;
    PlayerState state = PlayerState.Normal;
    PlayerController controller;
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    public void LateUpdate()
    {
        if (transform.position.y < deadLine)
        {
            Debug.Log("dead!");

            SceneManager.LoadScene("main");
        }
    }
}
