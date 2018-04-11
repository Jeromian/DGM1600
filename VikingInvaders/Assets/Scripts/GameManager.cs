using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int vikingCount;
    public Text healthText;
    public Text scoreText;
    public Text lifeText;
    private GameObject player;
    public int value;
    private int score;
    private int growScore;
    public Color colorTint;
    private GameManager myManager;


    /*void Awake()
    {
        if (instance == null)           //if instance is not assigned
        {                               //then assign instance to this object
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);   //then destroy this object
        }

        DontDestroyOnLoad(this.gameObject);
    }*/

    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        myManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        growScore = score = 0;
    }

    public void LoadLevel(string level)
    {
        vikingCount = 0;
        SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        vikingCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Update()
    {
        healthText.text = "HP: "+player.GetComponent<Health>().health;
        scoreText.text = score.ToString();
        if (growScore>=1000)
        {
            player.GetComponent<Lives>().IncrementLives(1);
            growScore -=1000;
        }
        lifeText.text = player.GetComponent<Lives>().lives.ToString();
    }
    
    public  void IncrementScore(int value)
    {
        score += value;
        growScore += value;
    }
}
