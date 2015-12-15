using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {	
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		levelManager.LoadLevel("Lose Screen");
	}

	void OnTriggerEnter2D(Collider2D collider) {
		levelManager.LoadLevel("Lose Screen");
	}
}
