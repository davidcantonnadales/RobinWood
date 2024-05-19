using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public static MusicManager instance;

	public AudioClip gameMusic;

	private AudioSource audioSource;

	void Awake()
	{
		if(MusicManager.instance != null)
		{
			Destroy(gameObject);	//do not allow more than one Music Manager on scene
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
		DontDestroyOnLoad (gameObject);
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.loop = true;
		audioSource.playOnAwake = true;
		audioSource.volume = 0.5f;
		audioSource.clip = gameMusic;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalValue.isMusic)
			audioSource.volume = 1;
		else
			audioSource.volume = 0;
	}
}
