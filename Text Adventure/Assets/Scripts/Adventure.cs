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
            Cell();
        }

        else if (currentState == States.window)
        {
            Window();
        }

        else if (currentState == States.bed)
        {
            Bed();
        }

        else if (currentState == States.door)
        {
            Door();
        }

        else if (currentState == States.teddy)
        {
            Teddybear();
        }

		else if (currentState == States.mattres)
		{
			Mattres();
		}

		else if (currentState == States.hall)
		{
			Hall();
		}

		else if (currentState == States.otherCell)
		{
			OtherCell();
		}

		else if (currentState == States.body)
		{
			Body();
		}

		else if (currentState == States.left)
		{
			Left();
		}

		else if (currentState == States.right)
		{
			Right();
		}

		else if (currentState == States.rush)
		{
			Rush();
		}

		else if (currentState == States.shank)
		{
			Shank();
		}

		else if (currentState == States.pod)
		{
			Pod();
		}

		else if (currentState == States.dead)
		{
			Dead();
		}

        lastState = currentState;
	}

    private void Cell()
    {
        print("You are in a tiny white sanitary well lit room with padded walls.\n" +
            "Press W for Window, D for Door, B for Bed.");
        textObject.text = "You are in a tiny white sanitary well lit room with padded walls.\n" +
            "Press W for Window, D for Door, B for Bed.";
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
                textObject.text = "You dont have the CODE to open the Door";
            }
        }
        
    }

    private void Teddybear()
    {
        print("Thw Teddybear is wearing a cute little labcoat and has a small tear in its neck.");
        if(doorCode == false)
        {
            print("OH!... You found a small paper with a code scrawled on it on the inside of the bears neck");
            doorCode = true;
        }
        print("Press B to go back to the Bed");
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
    }

	private void Mattres()
	{
		print("This mattres is hard as as a rock! OH... It is a rock.\n " +
			"Press B to go back to the Bed.");
		if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
	}

	private void Hall()
	{
		print("You're in a dimmly lit hall. You can go Left, Right, or enter the Other cell\n" +
			"Press L for Left, R for Right, O for Other cell.");
		if (Input.GetKeyDown(KeyCode.L)) { currentState = States.left; }
		if (Input.GetKeyDown(KeyCode.R)) { currentState = States.right; }
		if (Input.GetKeyDown(KeyCode.O)) { currentState = States.otherCell; }  
	}

	private void Left()
	{
		print("Oh look, an escape Pod. \n " +
			"Press H to go back to the Hall, P to enter the escape Pod.");
		if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
		if (Input.GetKeyDown(KeyCode.P)) {
			if (podKey == true) currentState = States.pod;
			else print("You dont have the key to open the escape Pod");
		}

	}

	private void Right()
	{
		print("Theres an armed guard! But luckily his back is turned to you. \n " +
			"Press S to go back to the Shank, R to enter the escape Rush.");
		if (Input.GetKeyDown(KeyCode.R)) { currentState = States.rush; }
		if (Input.GetKeyDown(KeyCode.S)) {
			if (podKey == true) currentState = States.shank;
			else print("You dont have anything to Shank him with.");
		}

	}

	private void Rush()
	{
		print("He Shot you!\n " +
			"72 times!");
		currentState = States.dead;
	}

	private void Dead()
	{
		print("GameOver");
	}

	private void Shank()
	{
		print("HAHAHA! YOU GOT HIS POD KEY! ");
			podKey = true;
		
		print("Press H to go back to the Hall");
		if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
	}

    private void OtherCell()
    {
        print("This cell is nearly identical to your own, but it's completely empty. Oh! Theres a dead Body in the middle of the floor!");
        print("Press B to check the Body, H to go back to the Hall");
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.body; }
        if (Input.GetKeyDown(KeyCode.H)) { currentState = States.hall; }
    }

    private void Body()
    {
        print("EEWWWW! This guy's been dead  for a while!");
        if (shiv == false)
        {
            print("OH!... YOU FOUND A SHIV in his ribcage. That's probably why he's dead.");
            shiv = true;
        }
        print("Press O to go back to the Other cell");
        if (Input.GetKeyDown(KeyCode.O)) { currentState = States.otherCell; }
    }

    private void Pod()
    {
        print("YOU ESCAPED!");
    }

}

