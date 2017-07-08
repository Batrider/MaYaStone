using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public Player hostPlayer;
    public List<BuffBase> buffList = new List<BuffBase>();

    public void Awake()
    {
        hostPlayer = GetComponent<Player>();
        Messenger.AddListener<BuffBase>(BuffEvent.Add, BuffAdd);
        Messenger.AddListener<BuffBase>(BuffEvent.Remove, BuffRemove);
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener<BuffBase>(BuffEvent.Add, BuffAdd);
        Messenger.RemoveListener<BuffBase>(BuffEvent.Remove, BuffRemove);
    }
    public void BuffAdd(BuffBase buff)
    {
        var myBuff = buffList.Find(x => x.buffId == buff.buffId);
        if (myBuff != null)
        {
            myBuff.buffTime = buff.buffTime;
        }
        else
        {
            buff.LogicStart();
            buffList.Add(buff);
        }
    }
    void BuffRemove(BuffBase buff)
    {
        buffList.RemoveAll(x => x.buffId == buff.buffId);
    }
    public void Excute()
    {
        for (int i = 0; i < buffList.Count; i++)
        {
            if (buffList[i].buffTime > 0)
            {
                buffList[i].LogicRun();
            }
            else
            {
                buffList[i].LogicEnd();
            }
        }
    }
}
