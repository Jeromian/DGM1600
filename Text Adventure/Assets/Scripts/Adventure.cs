using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour {

    public enum States { cell, window, door, bed, teddy, mattres, hall, otherCell, body, left, right, rush, shank, pod, dead}
    public States currentState;
    public States lastState;
    public bool doorCode;
    public bool shiv;
    public bool podKey;
    public Text textObject;
	public Text itemText;
    public Text title;




    // Use this for initialization
    void Start()
    {
        currentState = States.cell;
        doorCode = false;
        shiv = false;
        podKey = false;
        
    }


    
	
	// Update is called once per frame
	void Update() {
        if(currentState == States.cell)
        {
            title.text = ("CELL");
            Cell();
            if (doorCode) itemText.text = "You have the DOORCODE";
            else itemText.text = " ";
        }

        else if (currentState == States.window)
        {
            title.text = ("WINDOW");
            Window();
        }

        else if (currentState == States.bed)
        {
            title.text = ("BED");
            Bed();
            if (doorCode) itemText.text = "You have the DOORCODE";
            else itemText.text = " ";
        }

        else if (currentState == States.door)
        {
            title.text = ("Door");
            Door();
        }

        else if (currentState == States.teddy)
        {
            title.text = ("MR. FLUFFS");
            Teddybear();
        }

		else if (currentState == States.mattres)
		{
            title.text = ("MATTRES");
            Mattres();
		}

		else if (currentState == States.hall)
		{
            title.text = ("HALL");
            Hall();
            if (podKey) itemText.text = "You have the PODKEY";
            else if (shiv) itemText.text = "You have a SHIV";
            else itemText.text = " ";
        }

		else if (currentState == States.otherCell)
		{
            title.text = ("OTHER CELL");
            OtherCell();
            if (podKey) itemText.text = "You have the PODKEY";
            else if (shiv) itemText.text = "You have a SHIV";
            else itemText.text = " ";
        }

		else if (currentState == States.body)
		{
            title.text = ("BODY");
            Body();
		}

		else if (currentState == States.left)
		{
            title.text = ("LEFT");
            Left();
		}

		else if (currentState == States.right)
		{
            title.text = ("RIGHT");
            Right();
		}

		else if (currentState == States.rush)
		{
            title.text = ("RUSH");
            Rush();
            itemText.text = " ";
		}

		else if (currentState == States.shank)
		{
            title.text = ("MURDER!");
            Shank();
		}

		else if (currentState == States.pod)
		{
            title.text = (" ");
            Pod();
            itemText.text = " ";
        }

		else if (currentState == States.dead)
		{
            title.text = (" ");
            Dead();
        }

        lastState = currentState;
	}

    private void Cell()
    {
        print("You are in a tiny white steril well lit room with padded walls.\n" +
            "Press W for Window, D for Door, B for Bed.");
        textObject.text = "You are in a tiny white steril well lit room with padded walls.\n" +
            "Press W to check the Window, D to check Door, B to check the Bed.";
        if (Input.GetKeyDown(KeyCode.W)) { currentState = States.window; }
        if (Input.GetKeyDown(KeyCode.D)) { currentState = States.door; }
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }  
    }

    private void Window()
    {
        print("You look out the window and see twinkling stars and the planet down below you. " +
            "You feel as if the cold heart of space is staring at you.\n" +
            "Press C to go back to the Cell");
        textObject.text = "You look out the window and see twinkling stars and the planet down below you. " +
            "You feel as if the cold heart of space is staring at you.\n" +
            "Press C to go back to the Cell";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
    }

    private void Bed()
    {
        print("Your bed is ready-made with a cute little Teddybear sitting on top of the Mattres.\n " +
            "Press C to go back to the Cell, T to search the Teddybear, M to search the Mattres.");
        textObject.text = "Your bed is ready-made with a cute little Teddybear sitting on top of the Mattres.\n " +
            "Press C to go back to the Cell, T to search the Teddybear, M to search the Mattres.";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
        if (Input.GetKeyDown(KeyCode.T)) { currentState = States.teddy; }
        if (Input.GetKeyDown(KeyCode.M)) { currentState = States.mattres; }
    }

    private void Door()
    {
        print("The Door is solid iron with a small keypad over on one side. \n " +
            "Press C to go back to the Cell, K to use Keypad.");
        textObject.text = "The Door is solid iron with a small keypad over on one side. \n " +
            "Press C to go back to the Cell, K to use Keypad.";
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
        if (Input.GetKeyDown(KeyCode.K)) {
            if (doorCode == true) currentState = States.hall;
            else
            {
                print("You dont have the CODE to open the Door");
				itemText.text = "You dont have the CODE to open the Door";
            }
        }
        
    }

    private void Teddybear()
    {
        print("The Teddybear is wearing a cute little labcoat and has a small tear in its neck.");
		textObject.text = "The Teddybear is wearing a cute little labcoat and has a small tear in its neck. \n" +
			"Press B to go back to the Bed";

        if(doorCode == false)
        {
            print("OH!... You found a small paper with a code scrawled on it on the inside of the bears neck");
			itemText.text="OH!... You found a small paper with a code scrawled on it on the inside of the bears neck";
            doorCode = true;
        }
        print("Press B to go back to the Bed");
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
    }

	private void Mattres()
	{
		print("This mattres is hard as as a rock! OH... It is a rock.\n " +
			"Press B to go back to the Bed.");
		textObject.text = "This mattres is hard as as a rock! OH... It is a rock.\n " +
		"Press B to go back to the Bed.";
		if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
	}

	private void Hall()
	{
		print("You're in a dimmly lit hall. You can go Left, Right, or enter the Other cell\n" +
			"Press L for Left, R for Right, O for Other cell.");
		textObject.text = "You're in a dimmly lit hall. You can go Left, Right, or enter the Other cell\n" +
		"Press L for Left, R for Right, O for Other cell.";
		if (Input.GetKeyDown(KeyCode.L)) { currentState = States.left; }
		if (Input.GetKeyDown(KeyCode.R)) { currentState = States.right; }
		if (Input.GetKeyDown(KeyCode.O)) { currentState = States.otherCell; }  
	}

	private void Left()
	{
		print("Oh look, an escape Pod. \n " +
			"Press H to go back to the Hall, P to enter the escape Pod.");
		textObject.text = "Oh look, an escape Pod. \n " +
		"Press H to go back to the Hall, P to enter the escape Pod.";
		if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
		if (Input.GetKeyDown(KeyCode.P)) {
			if (podKey == true)
				currentState = States.pod;
			else {
				print ("You dont have the key to open the escape Pod");
				itemText.text = "You dont have the key to open the escape Pod";
			}
		}

	}

	private void Right()
	{
        if (podKey==false)
        {
            print("Theres an armed guard! But luckily his back is turned to you. \n " +
                "Press S to go back to the Shank, R to enter the escape Rush.");
            textObject.text = "Theres an armed guard! But luckily his back is turned to you. \n " +
            "Press S to Shank him, R to Rush him, H to go back to the Hall.";

            if (Input.GetKeyDown(KeyCode.R)) { currentState = States.rush; }
            if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (shiv == true) currentState = States.shank;
                else print("You dont have anything to Shank him with.");
                itemText.text = "You dont have anything to Shank him with.";
            }

        }

        else
        {
            textObject.text = "Theres that dead guard. Yup... Why are you still standing here? \n " +
            "Press H to go back to the Hall.";
            if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
        }

	}

	private void Rush()
	{
		print("He Shot you!\n " +
			"72 times!");
		textObject.text = "He Shot you!\n " +
		"72 times!\n " +
		"PRESS C";
		if (Input.GetKeyDown(KeyCode.C)) { currentState = States.dead; }

	}

	private void Dead()
	{
		print("GameOver");
		textObject.text = "GameOver";
	}

	private void Shank()
	{
		print("HAHAHA! YOU GOT HIS POD KEY! ");
		textObject.text = "HAHAHA! \n" +
			"Press H to go back to the Hall";
			podKey = true;
		
		print("Press H to go back to the Hall");
		itemText.text = "YOU GOT HIS POD KEY!";
		if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
	}

    private void OtherCell()
    {
        print("This cell is nearly identical to your own, but it's completely empty. Oh! Theres a dead Body in the middle of the floor!");
        print("Press B to check the Body, H to go back to the Hall");
		textObject.text = "This cell is nearly identical to your own, but it's completely empty. \n" +
			" Oh! Theres a dead Body in the middle of the floor! \n" +
			"Press B to check the Body, H to go back to the Hall";
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.body; }
        if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
    }

    private void Body()
    {
        print("EEWWWW! This guy's been dead  for a while!");
		textObject.text = "EEWWWW! This guy's been dead  for a while! \n" +
			"Press O to go back to the Other cell";
        if (shiv == false)
        {
            print("OH!... YOU FOUND A SHIV in his ribcage. That's probably why he's dead.");
			itemText.text = "OH!... YOU FOUND A SHIV in his ribcage. That's probably why he's dead.";
            shiv = true;
        }
        print("Press O to go back to the Other cell");
        if (Input.GetKeyDown(KeyCode.O)) { currentState = States.otherCell; }
    }

    private void Pod()
    {
        print("YOU ESCAPED!");
		textObject.text = "YOU ESCAPED!";
    }

}

