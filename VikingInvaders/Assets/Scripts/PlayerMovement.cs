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
    public GameObject ammo;
    private int count;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

	}

    

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

        if (Input.GetButton("Fire1")&count>15)
        {
            Instantiate(ammo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0), Quaternion.identity);
            count = 0;
        }

        count++;

	}

    

}
