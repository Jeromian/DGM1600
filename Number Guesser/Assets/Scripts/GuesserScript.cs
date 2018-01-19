using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuesserScript : MonoBehaviour {

        public int max;
        public int min;
    public int Guess;
    public int count;

	// Use this for initialization
	private void Start () {

        

        print("Welcome, you Fig Maggot!");
        print("pick a number between "+min+" and "+max);

        //Is value Guess
        NextGuess();
        //push buttons up/down
        print("press the up button for higher, the down button for lower, or the Enter key to confirm.");
        count++;
       max = max + 1;
    }

    private void NextGuess()
    {
 
        count--;
        if (count > 0)
        {
            Guess = Random.Range(min, max);
            print("Is it " + Guess);
        }
    }
	
	// Update is called once per frame
	public void Update () {

        if (count == 0)
        {
            print("NOOOOOOOO! YOU WIN!");
            count--;
        }

        else if (count > 0)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                min = Guess;
                print("AGGHHH! FINE!");
                NextGuess();
            }


            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                max = Guess;
                print("PSHH. BE THat WAY!");
                NextGuess();


            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {

                print("Realy? Your number is " + Guess + "!");
                if (Guess == 666)
                {
                    print("You must not have any friends.");
                }

                else
                {
                    print("I KNEW IT!");

                }
                count = -1;
                print("Play again?");
            }

        }
        
    }
}
