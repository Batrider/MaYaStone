using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float timeSlice = 0.02f;
    static Player hostPlayer;
    public static Player HostPlayer
    {
        get
        {
            if (hostPlayer == null)
            {
                var playerObj = GameObject.FindGameObjectWithTag("Player");
                if (playerObj != null)
                {
                    hostPlayer = playerObj.GetComponent<Player>();
                }
            }
            return hostPlayer;
        }
    }
    public static int ProgressPercent
    {
        get
        {
            return PlayerPrefs.GetInt("ProgressPercent");
        }
        set
        {
            PlayerPrefs.SetInt("ProgressPercent", value);
        }
    }


    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
