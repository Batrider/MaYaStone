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
    public GameObject pauseObj;
    // Use this for initialization
    void Start()
    {

        UIEventListener.Get(backBtn.gameObject).onClick = BackToMenu;
        UIEventListener.Get(resumeBtn.gameObject).onClick = Resume;
        UIEventListener.Get(restartBtn.gameObject).onClick = ReStart;


        Messenger.AddListener<GameState>(GameEvent.StateChange, StateChange);
        pauseObj.SetActive(false);

        TimeSpan t = new TimeSpan(0, 0, (int)GameManager.Instance.timeConsum);
        timeLb.text = string.Format("{0}:{1}", t.Minutes < 10 ? "0" + t.Minutes : t.Minutes.ToString(), t.Seconds < 10 ? "0" + t.Seconds : t.Seconds.ToString());
        progressLb.text = string.Format("{0}%", GameManager.Instance.CurPercent());
    }

    void StateChange(GameState state)
    {
        if (state == GameState.Play)
        {
            pauseObj.SetActive(false);
        }
        else if (state == GameState.Pause)
        {
            pauseObj.SetActive(true);
        }
        else if(state == GameState.End)
        {
            timeLb.gameObject.SetActive(false);
            resumeBtn.gameObject.SetActive(false);
            timeLb.gameObject.SetActive(false);
            progressLb.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if (Time.frameCount % 15 == 0)
        {
            TimeSpan t = new TimeSpan(0, 0, (int)GameManager.Instance.timeConsum);
            timeLb.text = string.Format("{0}:{1}", t.Minutes < 10 ? "0" + t.Minutes : t.Minutes.ToString(), t.Seconds < 10 ? "0" + t.Seconds : t.Seconds.ToString());
            progressLb.text = string.Format("{0}%", GameManager.Instance.CurPercent());
        }
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener<GameState>(GameEvent.StateChange, StateChange);
    }

    void Resume(GameObject obj)
    {
        if (GameManager.Instance.gameState == GameState.Pause)
        {
            GameManager.Instance.Play();
        }
        else if (GameManager.Instance.gameState == GameState.Play)
        {
            GameManager.Instance.Pause();
        }
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
