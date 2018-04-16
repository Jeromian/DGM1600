﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int health;
    public int worthScore;
    public ParticleSystem deathParticle;
    private GameObject deathReward;
    public GameObject[] drops;
    private int rand;
    public bool isPlayer;
    public bool justAmmo;
    public bool colourChangeCollision = false;
    public float count;
    public AudioClip hitSound;


    private void Start()
    {
        if (this.tag=="Enemy")
        {
            GameManager.vikingCount++;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "CannonBall")
        {
            IncrementHealth(-1);
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, 0));
            colourChangeCollision = true;
        }
        else if (this.tag == "CannonBall")
        {
            IncrementHealth(-1);
        }
        
       
    }

    private void Update()
    {
        HitColor();
    }

    private void HitColor()
    {
        if (colourChangeCollision)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
            
        }
        
        if (count > 20)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
            colourChangeCollision = false;
            count = 0;
        }
        count++;
    }

    public void IncrementHealth(int amount)
    {
        health += amount;
        if (health <= 0)
        {
            Drop();
            if (isPlayer)
            {
                FindObjectOfType<Lives>().IncrementLives(-1);
            }
            else if (this.tag =="Enemy")
            {
                
                GameManager.vikingCount--;
                FindObjectOfType<GameManager>().IncrementScore(worthScore);
                
            }
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        if (GameManager.vikingCount == 0)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
        if (isPlayer)
        {
            FindObjectOfType<GameManager>().LoadLevel("Loose");
        }
    }

    public void Drop()
    {
        if (deathParticle != null)
        {
            ParticleSystem particle = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(particle, particle.main.duration);
        }
        if (drops != null)
        {
            if (drops.Length != 1)
            {
                rand = Random.Range(0, 100);
                if (rand < 40)
                {
                    rand = 0;
                }
                else if (rand >= 40 && rand <= 79)
                {
                    rand = 1;
                }
                else if (rand >= 80)
                {
                    rand = 2;
                }
            }
            else
            {
                rand = 0;
            }
            deathReward = drops[rand];
            Instantiate(deathReward, gameObject.transform.position, Quaternion.identity);
        }
    }
}
