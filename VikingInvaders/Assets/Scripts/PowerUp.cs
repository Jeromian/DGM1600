using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerUp : MonoBehaviour {

    public enum Power { Health, Triple,Crate};
    public Power PowerUpType;
    public SpriteRenderer rend;
    public Sprite[] images;
    private GameObject player;
    public bool powerGet;

	// Use this for initialization
	void Start ()
    {

        rend=GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Health>().gameObject;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            powerGet = true;
            //Destroy(gameObject);
        }

        else
        {
            powerGet = false;
        }

    }

}
