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
    public GameObject ammo2;
    private int count;
    private int shotWeight;
    public bool tripleShot;
    public bool fastShot;
    public AudioClip fireSound;
    public static PlayerMovement instance = null;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

	}

    void Awake()
    {
        if (instance == null)           //if instance is not assigned
        {                               //then assign instance to this object
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);   //then destroy this object
        }

        DontDestroyOnLoad(this.gameObject);
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

        if (Input.GetButton("Fire1")&count>35)
        {
            Instantiate(ammo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0), Quaternion.identity);
            if (tripleShot)
            {
                Instantiate(ammo, new Vector3(gameObject.transform.position.x - .5f, gameObject.transform.position.y + 1, 0), Quaternion.identity);
                Instantiate(ammo, new Vector3(gameObject.transform.position.x + .5f, gameObject.transform.position.y + 1, 0), Quaternion.identity);
            }
            AudioSource.PlayClipAtPoint(fireSound, new Vector3(0, 0, 0));

            count = 0;
        }

        count++;
        
    }

    

}
