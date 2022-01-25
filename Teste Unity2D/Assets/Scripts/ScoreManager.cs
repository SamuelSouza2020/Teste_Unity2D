using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    GameManager gm;
    [SerializeField]
    Text txtRecord;
    void Start()
    {
        gm = GameObject.Find("Gerenc").GetComponent<GameManager>();
        txtRecord = GameObject.Find("BestRecord").GetComponent<Text>();
        GameStartScore();
    }
    void Update()
    {
        UpdateScore();
    }
    public void GameStartScore()
    {
        if(PlayerPrefs.HasKey("YourScore"))
        {
            score = PlayerPrefs.GetInt("YourScore");
        }
        else
        {
            score = 0;
            PlayerPrefs.SetInt("YourScore", score);
        }
        txtRecord.text = score.ToString();
    }
    public void UpdateScore()
    {
        score = PlayerPrefs.GetInt("YourScore");
    }
    public void SalvarScore()
    {
        if(gm.pontosPlayer > score)
        {
            score = gm.pontosPlayer;
        }
        txtRecord.text = score.ToString();
        PlayerPrefs.SetInt("YourScore", score);
    }
}
