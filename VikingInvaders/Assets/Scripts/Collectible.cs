using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour {

    public int value;
    public Color colorTint;
    private GameManager myManager;

    public void Start()
    {
        myManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        myManager.IncrementScore(1);
        Destroy(gameObject);
    }
}
