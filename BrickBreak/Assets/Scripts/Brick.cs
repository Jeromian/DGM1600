using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int health;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprites[0];
    }

    private void Awake()
    {
        GameManager.brickCount++;
        print(GameManager.brickCount);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        health--;
        GetComponent<SpriteRenderer>().sprite = sprites[health];

        
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
