using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int vikingCount;
    public Text healthText;
    private GameObject player;


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
    //    healthText.text = "Health"+player.GetComponent<Health>().health;
    }
}
