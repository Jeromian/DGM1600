﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

    private int score;
    private int lives;
    private int finalScore;
    public Text finalScoreText;

	// Use this for initialization
	void Start ()
    {
        score=FindObjectOfType<GameManager>().score;
        lives=FindObjectOfType<Lives>().lives;
        finalScore = score * lives;
        finalScoreText.text =score.ToString()+"points x "+lives.ToString()+"lives = "+ finalScore.ToString();
    }
}
