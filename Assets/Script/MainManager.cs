using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public static MainManager inst;


    private int score = 0;
    private int bestscore = 0;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        bestscore = PlayerPrefs.GetInt("bestscore", 0);
        score = 0;
        AddScore(0);
        BestScore();
        
    }


    void Update()
    {

    }

    public void AddScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score : " + score;
        if(bestscore < score)
        {
            PlayerPrefs.SetInt("bestscore", score);
        }
        
    }

    public void BestScore()
    {
        bestScoreText.text = "Best Score: " + bestscore;
    }


}
