using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{
 
    private int score = 0;

    [SerializeField] Text scoreText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
 

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (scoreText)
        {
            scoreText.text = score.ToString();
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
    }
    public int GetFinalScore()
    {
        return score;
    }
}
