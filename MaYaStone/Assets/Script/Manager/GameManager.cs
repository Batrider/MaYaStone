using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const float timeSlice = 0.02f;
    public GameState gameState = GameState.Play;
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
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (new GameObject("GameManager")).AddComponent<GameManager>();
            }
            return instance;
        }
    }
    public float timeConsum = 0;
    public int curLevel = 0;
    public AudioSource audioSource;
    public int Score
    {
        get
        {
            return PlayerPrefs.GetInt("Score", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Score", value);
        }
    }
    public int Percent
    {
        get
        {
            return PlayerPrefs.GetInt("Percent", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Percent", value);
        }
    }
    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.loop = false;
            }
            audioSource.PlayOneShot(clip);
        }
    }
    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == GameState.Play)
            {
                Pause();
            }
            else if(gameState == GameState.Pause)
            {
                Play();
            }
        }
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == GameState.Play)
            {
                Pause();
            }
        }
        if (gameState == GameState.Play)
        {
            timeConsum += Time.deltaTime;
        }
    }
    public void Pause()
    {
        gameState = GameState.Pause;
        Time.timeScale = 0;
        Messenger.Broadcast<GameState>(GameEvent.StateChange, gameState);
    }
    public void Play()
    {
        gameState = GameState.Play;
        Time.timeScale = 1;
        Messenger.Broadcast<GameState>(GameEvent.StateChange, gameState);
    }
    public void BackToMenu()
    {
        gameState = GameState.Play;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void LoadLevel(int stageIndex)
    {
        curLevel = stageIndex;
        gameState = GameState.Play;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + stageIndex);
    }

    public void OnLevelWasLoaded(int level)
    {
        if (curLevel > 0)
        {
            timeConsum = 0;
        }
    }
    public void BttleEnd()
    {
        gameState = GameState.End;
        Messenger.Broadcast<GameState>(GameEvent.StateChange, gameState);
    }
    public void GetGold(int score)
    {
        Score += score;
    }
    public int CurPercent()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            GameObject startPoint = GameObject.FindGameObjectWithTag("startPoint");
            GameObject endPoint = GameObject.FindGameObjectWithTag("endPoint");
            if (startPoint != null && endPoint != null)
            {
                float totalDistance = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);
                float curDistance = Vector3.Distance(player.transform.position, startPoint.transform.position);
                return (int)(100 * curDistance / totalDistance);
            }
        }
        return 0;
    }
}
