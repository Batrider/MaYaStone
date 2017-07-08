using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float deadLine = -12;
    PlayerState state = PlayerState.Normal;
    PlayerController controller;
    BuffManager buffManager;
    public Vector3 playerScale;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        buffManager = GetComponent<BuffManager>();
        playerScale = transform.localScale;

        Messenger.AddListener(PlayerEvent.Dead, Dead);
        Messenger.AddListener<PlayerState>(PlayerEvent.ChangeState, ChangeState);
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener(PlayerEvent.Dead, Dead);
        Messenger.RemoveListener<PlayerState>(PlayerEvent.ChangeState, ChangeState);
    }

    public void ChangeState(PlayerState state)
    {
        this.state = state;
    }
    public void Dead()
    {
        if (state != PlayerState.God)
        {
            //播放死亡特效--
            Debug.Log("dead!");
            Destroy(gameObject);
            //Messenger.Cleanup();
            SceneManager.LoadSceneAsync("main");
        }
    }
    public void Update()
    {
        buffManager.Excute();

    }

    public void LateUpdate()
    {
        if (transform.position.y < deadLine)
        {
            Dead();
        }
    }
}
