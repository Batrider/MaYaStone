using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColossalBurgerBuff : BuffBase {

    public float size;
    public override void LogicStart()
    {
        iTween.ScaleBy(hostPlayer, size * Vector3.one, 0.1f);
    }
    public override void LogicRun()
    {
        base.LogicRun();
    }
    public override void LogicEnd()
    {
        iTween.ScaleBy(hostPlayer, 1 / size * Vector3.one, 0.1f);
    }
}
