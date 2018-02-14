using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay;
    private GameObject ball;

    private void Start()
    {
        ball = FindObjectOfType<BallScript>().gameObject;
    }

    void Update ()
    {
        //get paddle position
        Vector3 paddlePosition = new Vector3(0, gameObject.transform.position.y, 0);
        if (autoPlay)
        {
            paddlePosition.x = ball.transform.position.x;
        }

        else
        {
        //get mouse position
        float mousePositionX = (Input.mousePosition.x / Screen.width * 16)-10;
        //convert mouse position to world space
        //save new position
        paddlePosition.x = mousePositionX;
        }

        //set this paddle object to saved position
        this.gameObject.transform.position = paddlePosition;
	}
}
