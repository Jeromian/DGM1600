using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D rigid;
    public float speed;
    public GameObject ammo1;
    public GameObject ammo2;
    private int count;
    public int rand;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Vector3 centralPosition = new Vector3(0, gameObject.transform.position.y, 0);
        Vector3 vikingPosition = new Vector3(0, gameObject.transform.position.y, 0);
        if (this.gameObject.transform.position.x + .15 < player.transform.position.x)
        {
            rigid.AddForce(new Vector2(speed, 0));
        }

        else if (this.gameObject.transform.position.x - .15 > player.transform.position.x)
        {
            rigid.AddForce(new Vector2(-1 * speed, 0));
        }
       /* else
        {
            centralPosition.x = player.transform.position.x;

            this.gameObject.transform.position = centralPosition;
        }*/

        if (count > 100)
        {
            rand = Random.Range(1,100);

            if (rand < 30)
            {
                Instantiate(ammo1, new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y - 2, 0), Quaternion.identity);
            }

            else
            {
                Instantiate(ammo1, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y - 2, 0), Quaternion.identity);
            }

            Instantiate(ammo2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2, 0), Quaternion.identity);

            count = 0;
        }

        count++;

    }

}

