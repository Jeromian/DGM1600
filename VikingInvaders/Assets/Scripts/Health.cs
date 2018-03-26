using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    public ParticleSystem deathParticle;
    public bool isCannonBalled;
    public bool isPlayer;

    private void Awake()
    {
        if (!isPlayer)
        {
            GameManager.vikingCount++;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "CannonBall")
        {
            isCannonBalled = true;
        }

        else
        {
            isCannonBalled = false;
        }

        if (isCannonBalled)
        {
            health--;
        }

        else if(this.tag == "CannonBall")
        {
            health--;
        }
        
        if (health <= 0)
        {
        //Instantiate(deathParticle, gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
            GameManager.vikingCount--;
            if (GameManager.vikingCount == 0)
            {
                FindObjectOfType<GameManager>().LoadNextLevel();
            }
            if (isPlayer)
            {
                FindObjectOfType<GameManager>().LoadLevel("Lose");
            }
        }

    }
}
