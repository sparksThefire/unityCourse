using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private float mousePosInBlocks;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;

		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7f, 6f);

		this.transform.position = paddlePos;
	}
}
