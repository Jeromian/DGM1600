using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;

	private void OnCollisionEnter2D(Collision2D collision) {
        health--;
        //if health is 0 then destroy
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
	
}
