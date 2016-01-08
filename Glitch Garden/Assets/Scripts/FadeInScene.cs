using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInScene : MonoBehaviour {

    public float fadeInTime;

    private Image panel;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start() { 
        panel = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphachange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphachange;
            panel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
