using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResult : MonoBehaviour {


    public UIButton backBtn;
    public UIButton restartBtn;
    public UILabel progressLb;
    public UILabel scoreLb;
    public UILabel historyScoreLb;

    // Use this for initialization
    void Start () {

        UIEventListener.Get(backBtn.gameObject).onClick = BackToMenu;
        UIEventListener.Get(restartBtn.gameObject).onClick = ReStart;

        Messenger.AddListener<GameState>(GameEvent.StateChange, StateChange);

        gameObject.SetActive(false);
    }
    public void OnDestroy()
    {
        Messenger.RemoveListener<GameState>(GameEvent.StateChange, StateChange);
    }
    void StateChange(GameState state)
    {
        if (state == GameState.End)
        {
            gameObject.SetActive(true);
            progressLb.text = string.Format("{0}%", GameManager.Instance.Percent);
            historyScoreLb.text = GameManager.Instance.Score.ToString();


            int historyScore = GameManager.Instance.Score;
            historyScoreLb.text = historyScore.ToString();
            int historyPercent = GameManager.Instance.Percent;

            int curPercent = GameManager.Instance.CurPercent();
            int curSocre = Mathf.CeilToInt(1000000f * curPercent / GameManager.Instance.timeConsum);
            if (curSocre > historyScore)
            {
                GameManager.Instance.Score = curSocre;
            }
            if (curPercent > historyPercent)
            {
                GameManager.Instance.Percent = curPercent;
            }
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
