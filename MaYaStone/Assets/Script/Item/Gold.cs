using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    private int score;
    public AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GetGold(score);
            GameManager.Instance.PlayClip(clip);
            gameObject.SetActive(false);
        }
    }
}
