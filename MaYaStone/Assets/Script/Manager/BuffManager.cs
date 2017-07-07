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
    }

    public void OnDestroy()
    {
        Messenger.RemoveListener<BuffBase>(BuffEvent.Add, BuffAdd);
    }
    void BuffAdd(BuffBase buff)
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
        buffList.RemoveAll(x => x.buffTime < 0);
    }
}
