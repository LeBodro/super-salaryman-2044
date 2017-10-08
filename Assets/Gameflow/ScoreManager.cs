using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int score = 0;
    int levelScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelScoreText;

    [SerializeField] int successPoints;
    [SerializeField] int failPoints;
    //[SerializeField] int pointsPerSecondsLeft;

    public void ScoreWrongAnswer()
    {
        score -= failPoints;
        scoreText.text = "Score: " + score;

        levelScore -= failPoints;
        levelScoreText.text = "LevelScore: " + levelScore;
    }

    public void ScoreRightAnswer()
    {
        score += successPoints;
        scoreText.text = "Score: " + score;

        levelScore += successPoints;
        levelScoreText.text = "LevelScore: " + levelScore;
    }

    public void ResetScore()
    {
        levelScore = 0;
        levelScoreText.text = "LevelScore: " + levelScore;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
