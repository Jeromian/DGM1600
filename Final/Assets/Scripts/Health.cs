using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    public ParticleSystem deathParticle;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;

        if (health <= 0)
        {
        Instantiate(deathParticle, gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
        }

    }
}
