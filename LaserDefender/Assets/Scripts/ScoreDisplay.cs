using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GameObject.Find("Score").GetComponent<Text>();
        myText.text = string.Format("Score: {0}",ScoreKeeper.score.ToString());
        ScoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
