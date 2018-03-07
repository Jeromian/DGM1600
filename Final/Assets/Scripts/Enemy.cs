using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rigid;
    public float speed;
    private Animator anim;
    private SpriteRenderer rend;
    public bool gotHit;
    public int stunTime;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Stuned", gotHit);
        if (stunTime == 150) gotHit = false;
        stunTime++;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gotHit = true;
        stunTime = 0;
    }

}
