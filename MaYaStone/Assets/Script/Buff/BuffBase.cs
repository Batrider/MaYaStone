using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase {

    public float buffTime;
    public int buffId;
    public GameObject hostPlayer;
    public virtual void LogicStart()
    {

    }

    public virtual void LogicRun()
    {
        buffTime -= GameManager.timeSlice;
    }
    public virtual void LogicEnd()
    {

    }
}
