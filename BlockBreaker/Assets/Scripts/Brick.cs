using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
    public GameObject smokePrefab;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = ( this.tag == "Breakable" );
		if (isBreakable) { breakableCount++; }

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.25f);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			Debug.Log ("Breakable count: " + breakableCount);
            PuffSmoke();
			levelManager.BrickDestroyed();
			Destroy(gameObject);

		} else {
			LoadSprites();
		}
	}

    void PuffSmoke() {
        GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity) as GameObject;
        smoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}

}
