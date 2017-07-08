using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{

    public UIButton backBtn;
    public UIButton resumeBtn;
    public UIButton restartBtn;
    public UILabel timeLb;
    public UILabel progressLb;
    // Use this for initialization
    void Start()
    {

        UIEventListener.Get(backBtn.gameObject).onClick = BackToMenu;
        UIEventListener.Get(resumeBtn.gameObject).onClick = Resume;
        UIEventListener.Get(restartBtn.gameObject).onClick = ReStart;



        TimeSpan t = new TimeSpan(0, 0, (int)GameManager.Instance.timeConsum);
        timeLb.text = string.Format("{0}:{1}", t.TotalMinutes, t.Seconds);

        Messenger.AddListener<GameState>(GameEvent.StateChange, StateChange);

        gameObject.SetActive(false);
    }

    void StateChange(GameState state)
    {
        if (state == GameState.Play)
        {
            gameObject.SetActive(false);
        }
        else if (state == GameState.Pause)
        {
            gameObject.SetActive(true);
        }
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener<GameState>(GameEvent.StateChange, StateChange);
    }

    void Resume(GameObject obj)
    {
        GameManager.Instance.Play();
    }

    void BackToMenu(GameObject obj)
    {
        GameManager.Instance.BackToMenu();
    }
    void ReStart(GameObject obj)
    {
        if (GameManager.Instance.curLevel > 0)
        {
            GameManager.Instance.LoadLevel(GameManager.Instance.curLevel);
        }
    }
}
