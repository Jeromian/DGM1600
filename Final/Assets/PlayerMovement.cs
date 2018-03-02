using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid;
    public float speed;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //check for button pushes

        rigid.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed, 0));

        
	}
}
