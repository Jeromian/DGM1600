using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D rigid;
    public float speed;
    public GameObject ammo;
    private int count;
    public AudioClip fireSound;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
            rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Vector3 centralPosition = new Vector3(0, gameObject.transform.position.y, 0);
        Vector3 vikingPosition = new Vector3(0, gameObject.transform.position.y, 0);
        if (this.gameObject.transform.position.x+.15 < player.transform.position.x)
        {
            rigid.AddForce(new Vector2(speed, 0));
        }

        else if (this.gameObject.transform.position.x-.15 > player.transform.position.x)
        {
            rigid.AddForce(new Vector2(-1*speed, 0));
        }
       /* else
        {
            centralPosition.x = player.transform.position.x;
            
            this.gameObject.transform.position = centralPosition;
        }*/

        if (count > 130)
        {
           Instantiate(ammo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-1,0), Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireSound, new Vector3(0, 0, 0));
            count = 0;
        }

        count++;

    }
    
}
