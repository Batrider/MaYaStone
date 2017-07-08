using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

    public UILabel progressLb;
    public UITexture uiTexture;
    public UIScrollView scrollView;
    public UICenterOnChild centerChild;
    public List<UIStageItem> stageList = new List<UIStageItem>();
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < stageList.Count; i++)
        {
            int index = i;
            UIEventListener.Get(stageList[index].boxColliderObj).onClick = (x) => OpenStage(stageList[index]);
        }
        centerChild.onFinished += OnCenterFinish;
    }

    void OpenStage(UIStageItem stage)
    {
        if (stage.stageIndex == 1)
        {
            SceneManager.LoadScene("Level1");
        }
    }
    void OnCenterFinish()
    {
        UIStageItem item = centerChild.centeredObject.GetComponent<UIStageItem>();
        uiTexture.mainTexture = item.bgTexture;
        progressLb.text = string.Format("{0}%", item.stageIndex);
    }
}
