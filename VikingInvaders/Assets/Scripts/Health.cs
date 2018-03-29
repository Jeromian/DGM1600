using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int health;
<<<<<<< Updated upstream
    public ParticleSystem deathParticle;
    public GameObject deathReward;
=======
    public GameObject deathParticle;
>>>>>>> Stashed changes
    public bool isCannonBalled;
    public bool isPlayer;
    public bool colourChangeCollision = false;
    public float count;
    public Text healthText;
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
<<<<<<< Updated upstream
            //Instantiate(deathParticle, gameObject.transform.position,Quaternion.identity);
            if (deathReward != null)
            {
                Instantiate(deathReward, gameObject.transform.position, Quaternion.identity);
            }
        Destroy(gameObject);
=======
            if (deathParticle != null)
            {
                Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
>>>>>>> Stashed changes
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
        if (isPlayer)
        {
            healthText.text = ("HEALTH"+health);
        }
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
