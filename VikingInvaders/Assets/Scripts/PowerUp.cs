using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerUp : MonoBehaviour {

    public enum Power { Health, Triple,Crate};
    public Power PowerUpType;
    public SpriteRenderer rend;
    public Sprite[] images;

	// Use this for initialization
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
}
