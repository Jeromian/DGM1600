using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives;
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
        lives += value;
        if (lives <= 0)
        {
            player.GetComponent<Health>().Die();
        }
        else if (value < 0)
        {
            player.GetComponent<Health>().health = 5;
        }
        else
        {
            AudioSource.PlayClipAtPoint(lifeGet, new Vector3(0, 0, 0));
        }
    }
}
