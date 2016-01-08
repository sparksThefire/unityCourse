using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private static int currentMusicLevel = 0;
    private AudioSource audioSource;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't Destroy on load: " + name);
    }

	// Use this for initialization
	public void Start () { 
        audioSource = GetComponent<AudioSource>();
        ChangeVolume(PlayerPrefsManager.GetMasterVolume());
    }
	
	// Update is called once per frame
	public void OnLevelWasLoaded (int level) {

        AudioClip levelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + levelMusic);

        if (levelMusic) // if there is some music attached
        {
            audioSource.clip = levelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
	}

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
