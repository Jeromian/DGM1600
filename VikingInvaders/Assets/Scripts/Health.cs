using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    public ParticleSystem deathParticle;
    public bool isCannonBalled;
    public bool isPlayer;
    public bool colourChangeCollision = false;
    public float count;
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

            if (this.transform.tag != "CannonBall")
            {
                colourChangeCollision = true;
            }
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
                FindObjectOfType<GameManager>().LoadLevel("Loose");
            }
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
}
