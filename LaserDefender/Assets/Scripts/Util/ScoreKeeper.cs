using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;

    private Text myText;

    public void Start()
    {
        myText = GameObject.Find("Score").GetComponent<Text>();
    }

	public void Score(int points)
    {
        score += points;
        WriteScore();
    }

    public static void Reset()
    {
        score = 0;
    }

    private void WriteScore()
    {
        if (myText) {
            myText.text = string.Format("Score: {0}", score);
        }
    }
}
