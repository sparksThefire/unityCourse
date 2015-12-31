using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer instance = null;

	void Awake() {
		if (instance != null) {
			Destroy (gameObject);
			Debug.Log("Duplicate self, self-destructing");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	public void PlayBoing() {
	}

	public void PlayCrack() {
	}
}
