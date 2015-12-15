using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States { CELL, MIRROR, LOCK_0, SHEETS_0, CELL_MIRROR, SHEETS_1, LOCK_1, FREEDOM };
	private States currentState = States.CELL;

	// Use this for initialization
	void Start () {
		text.text = "Hello World!";
	}
	
	// Update is called once per frame
	void Update () {
		print ("Current State is: " + currentState);

		switch (currentState) {
		case States.CELL :
			state_cell();
			break;
		case States.SHEETS_0 :
			state_sheets_0();
			break;
		case States.LOCK_0 :
			state_lock_0();
			break;
		case States.MIRROR :
			state_mirror();
			break;
		case States.CELL_MIRROR :
			state_cell_mirror();
			break;
		case States.SHEETS_1 : 
			state_sheets_1();
			break;
		case States.LOCK_1 :
			state_lock_1();
			break;
		case States.FREEDOM :
			state_freedom();
			break;
		default:
			break;
		}
	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " + 
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, or L to view Lock. ";
		
		
		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = States.SHEETS_0;

		} else if (Input.GetKeyDown (KeyCode.L)) {
			currentState = States.LOCK_0;

		} else if (Input.GetKeyDown (KeyCode.M)) {
			currentState = States.MIRROR;
			
		}
	}

	void state_sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" +
					"Press R to Return to roaming your cell";

		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.CELL;
		}
	}  

	void state_lock_0 () {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.CELL;
		}
	}    
	
	void state_mirror () {
		text.text = "This mirror may help you see things you couldn't before, you pick it up.\n\n" +
					"Press R to Return to roaming your cell";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.CELL_MIRROR;
		}
	}

	void state_cell_mirror() {
		text.text = "With the Mirror in hand, you aim to leave your cell.\n\n" +
					"Press S to view Sheets, or L to view Lock. ";
		
		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = States.SHEETS_1;
			
		} else if (Input.GetKeyDown (KeyCode.L)) {
			currentState = States.LOCK_1;
			
		} 
	}
	
	void state_lock_1 () {
		text.text = "You carefully put the mirror through the bars and turn it round " +
					"so you can see the lock. You can just make out the fingerprints around the " +
					"buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open the lock";
		
		if (Input.GetKeyDown (KeyCode.O)) {
			currentState = States.FREEDOM;
		}
	}
	
	void state_sheets_1 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " + 
					"I guess!\n\n" +
					"Press R to Return to roaming your cell";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.CELL_MIRROR;
		}
	}  

	
	
	void state_freedom () {
		text.text = "The barred door slides open. Freedom is almost yours, you just " +
					"have to make it out without any of the guards noticing you.\n\n" +
					"Press R to Replay the game";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.CELL;
		}
	} 
}
