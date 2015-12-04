using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	private int min;
	private int max;
	private int guess;

	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			print ("Up Arrow Pressed");
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			print ("Down Array Pressed");
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown (KeyCode.Return)) {
			print("I won!");
			StartGame();
		}
	}

	void NextGuess() {
		guess = (max + min + 1) / 2;
		print ("Is the number higher or lower than " + guess + "?");
	}

	void StartGame() {
		
		min = 1;
		max = 1000;
		guess = 500;

		print ("Welcome to Number Wizard.");
		print ("Pick a number in your head, but don't tell me.");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
//		max = max + 1;
		
		NextGuess ();
		print ("Up = higher, down =  lower, return = equal");
	}

}
