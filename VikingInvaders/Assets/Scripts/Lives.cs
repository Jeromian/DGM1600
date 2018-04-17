using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives;
    public int wasLives;
    private GameObject player;
    public AudioClip lifeGet;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        lives = 1;
    }

    public void IncrementLives(int value)
    {
        wasLives = lives;
        lives += value;
        if (lives <= 0)
        {
            player.GetComponent<Health>().Die();
        }
        else if (lives < wasLives)
        {
            player.GetComponent<Health>().health = 5;
        }
    }
}
