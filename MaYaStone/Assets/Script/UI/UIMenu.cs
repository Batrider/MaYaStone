using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        GameManager manager = GameManager.Instance;
    }

    void OpenStage(UIStageItem stage)
    {
        if (stage.stageIndex == 1)
        {
            GameManager.Instance.LoadLevel(stage.stageIndex);
        }
    }
    void OnCenterFinish()
    {
        UIStageItem item = centerChild.centeredObject.GetComponent<UIStageItem>();
        uiTexture.mainTexture = item.bgTexture;
        progressLb.text = string.Format("{0}%", item.stageIndex);
    }
}
