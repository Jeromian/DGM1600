using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public Health HealthScript;
    public ParticleSystem deathParticle;

    private void Start()
    {
        HealthScript = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        HealthScript.health--;
        if (HealthScript.health <= 0)
        {
            ParticleSystem particle = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(particle, particle.main.duration);
        }
    }
}
