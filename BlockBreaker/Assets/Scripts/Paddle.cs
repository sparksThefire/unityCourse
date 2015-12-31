using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball; 
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		Debug.Log (ball);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7f, 6f);
		
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x -.5f, -7f, 6f);
		
		this.transform.position = paddlePos;
	}
}
