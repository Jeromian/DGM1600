using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    private int totalHealth;
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
    }

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
            ChangeSprite();
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

    void ChangeSprite()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

}
