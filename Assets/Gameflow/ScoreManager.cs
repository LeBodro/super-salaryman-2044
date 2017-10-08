using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] int successPoints;
    [SerializeField] int failPoints;

    public void ScoreWrongAnswer()
    {
        score -= failPoints;
        scoreText.text = "Score = " + score;
    }

    public void ScoreRightAnswer()
    {
        score += successPoints;
        scoreText.text = "Score = " + score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score = " + score;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
