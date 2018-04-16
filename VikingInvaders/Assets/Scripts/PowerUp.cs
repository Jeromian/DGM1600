using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerUp : MonoBehaviour {

    public enum Power { Health, Triple, Crate};
    public Power PowerUpType;
    public SpriteRenderer rend;
    public Sprite[] images;
    private GameObject player;
    public bool powerGet;

	void Start ()
    {
        rend=GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (PowerUpType)
        {
            case Power.Health:
                rend.sprite = images[0];
                break;
            case Power.Triple:
                rend.sprite = images[1];
                break;
            case Power.Crate:
                rend.sprite = images[2];
                break;
        }
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (PowerUpType)
            {
                case Power.Health:
                    collision.GetComponent<Health>().IncrementHealth(1);
                    break;
                case Power.Triple:
                    collision.GetComponent<PlayerMovement>().tripleShot = true;
                    break;
                case Power.Crate:
                    //collision.GetComponent<Lives>().IncrementLives(1);
                    FindObjectOfType<GameManager>().IncrementScore(Random.Range(1, 50));
                    break;
            }
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
