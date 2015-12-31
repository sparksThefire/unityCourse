﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {	
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Lost ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Lost ();
	}

	private void Lost() {
		levelManager.LoadLevel("Lose Screen");
	}
}
