using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    private int totalHealth;

    private void Awake()
    {
        GameManager.brickCount++;
        print(GameManager.brickCount);
        totalHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        health--;

        if (health<=totalHealth/2)
        {
            print("HALF");
            
        }
        //if health is 0 then destroy
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.brickCount--;
            print(GameManager.brickCount);
            if (GameManager.brickCount == 0)
            {
                FindObjectOfType<GameManager>().LoadNextLevel();
            }
        }
    }
	
}
