using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public GameManager theGameManager;

	
	void Start ()
    {
        theGameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("GAME OVER");
        theGameManager.LoadLevel("GameOver");
    }

}
