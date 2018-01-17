using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuesserScript : MonoBehaviour {

        public int max;
        public int min;
    public int Guess;
        

	// Use this for initialization
	private void Start () {

        

        print("Welcome, you Fig Maggot!");
        print("pick a number between "+min+" and "+max);

        //Is value Guess
        print("is it "+Guess+"?");
        //push buttons up/down
        print("press the up button for higher, the down button for lower, or the Spacebar to confirm.");

       
    }
	
	// Update is called once per frame
	public void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = Guess;
            Guess = (min + max) / 2;
            print("Is it" + Guess);

        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = Guess;
            Guess = (min + max) / 2;
            print("Is it" + Guess);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            print("HAHA I KNEW IT WAS " + Guess+"!");

        }

    }
}
