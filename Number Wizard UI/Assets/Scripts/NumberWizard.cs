using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	private int min;
	private int max;
	private int guess;

	public Text text;

	private int maxGuesses = 11;

	public void Start() {
		StartGame();
	}

	public void GuessHigher() {
		min = guess;
		NextGuess();
	}

	public void GuessLower(){
		max = guess;
		NextGuess();
	}

	public void GuessCorrect() {
		Debug.Log ("Correct Guess");
		Application.LoadLevel("Win");
	}

	private void NextGuess() {
//		guess = (max + min ) / 2;
		guess = Random.Range(min, max + 1);
		maxGuesses -= 1;

		if (maxGuesses <= 0) {
			Application.LoadLevel("Lose");
		}

		text.text = "Your Number is: " + guess;
	}

	private void StartGame() {
		
		min = 1;
		max = 1000;

		
		NextGuess ();
	}

	private void LoseGame() {
	
	}
}
