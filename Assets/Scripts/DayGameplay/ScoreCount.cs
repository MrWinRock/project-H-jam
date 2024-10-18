using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        //UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score: " + score);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore()
    {
        score += 1;
        
    }
    // void UpdateScore()
    // {
    //     void OnTriggerEnter2D(Collision2D collision){
    //         if (collision.CompareTag("Shaman"))
    //         {
    //             SaveScore();
    //             Debug.Log("Score: " + score);
    //         }
    //     }
    // }

    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ghost")) 
        {
            AddScore();
        }
    }
    public int GetScore()
    {
        return score;
    }
}