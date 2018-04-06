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
    private GameObject player;
    public int value;
    private int score;
    public Color colorTint;
    private GameManager myManager;


    void Awake()
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
    }

    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        myManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
        healthText.text = "Health: "+player.GetComponent<Health>().health;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
    }

    public  void IncrementScore(int value)
    {
        score += value;
        scoreText.text = value.ToString();

    }
}
