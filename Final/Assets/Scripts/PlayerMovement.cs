using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid;
    public float speed;
    private Animator anim;
    private SpriteRenderer rend;
    public float jump;
    private bool isGrounded;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //check for button pushes

        rigid.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed, 0));
        anim.SetFloat("HorizontalGo", Input.GetAxisRaw("Horizontal"));
        if(Input.GetAxisRaw("Horizontal")< -0.1f)
        {
            // flip sprite renderer
            rend.flipX = true;
        }
        else
        {
            //unFlip
            rend.flipX = false;
        }

        if (Input.GetButton("Fire1"))
        {
            anim.SetTrigger("ShootGo");
        }

        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,1f,9);
            if (hit.collider.tag == "Ground")
            {
                isGrounded = true;
                Debug.Log("Found Ground");
            }
            else
            {
                isGrounded = false;
                Debug.Log("No Ground");
            }

            if (isGrounded)
            {
                rigid.AddForce(new Vector2(0, jump), ForceMode2D.Force);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
