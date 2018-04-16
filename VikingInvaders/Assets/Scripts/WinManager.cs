using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

    private int score;
    private int lives;
    private int finalScore;
    public Text equalsText;
    public Text finalScoreText;
    private PlayerMovement player;

	// Use this for initialization
	void Start ()
    {
        
        score =FindObjectOfType<GameManager>().score;
        lives=FindObjectOfType<Lives>().lives;
        finalScore = score * lives;
        equalsText.text = score.ToString() + "points x " + lives.ToString() + "lives = ";
        finalScoreText.text = finalScore.ToString();
        Destroy(FindObjectOfType<Health>().gameObject);
    }
}
