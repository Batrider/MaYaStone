using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColossalBurgerBuff : BuffBase {

    public float size;
    public override void LogicStart()
    {
        Messenger.Broadcast<PlayerState>(PlayerEvent.ChangeState, PlayerState.God);
        iTween.ScaleBy(hostPlayer, size * Vector3.one, 0.5f);
    }
    public override void LogicRun()
    {
        base.LogicRun();
    }
    public override void LogicEnd()
    {
        iTween.ScaleBy(hostPlayer, 1 / size * Vector3.one, 0.5f);
        Messenger.Broadcast<PlayerState>(PlayerEvent.ChangeState, PlayerState.Normal);
        Messenger.Broadcast<BuffBase>(BuffEvent.Remove, this);
    }
}
