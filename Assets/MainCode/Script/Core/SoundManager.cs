using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip[] musics;
	public AudioClip[] sounds;

	private static SoundManager instance;

	private AudioSource musicAudio;
	private AudioSource soundFx;

	//GET and SET
	public static float MusicVolume{
		set{ instance.musicAudio.volume = value; }
		get{ return instance.musicAudio.volume; }
	}
	public static float SoundVolume{
		set{ instance.soundFx.volume = value; }
		get{ return instance.soundFx.volume; }
	}
	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		musicAudio = gameObject.AddComponent<AudioSource> ();
		musicAudio.loop = true;
		musicAudio.volume = 0.5f;
		soundFx = gameObject.AddComponent<AudioSource> ();

		PlayMusic ("Music");

		//Check auido and sound
		if (!GlobalValue.isMusic)
			musicAudio.volume = 0;
		if (!GlobalValue.isSound)
			soundFx.volume = 0;
	}

	public static void PlaySfx(AudioClip clip){
		instance.PlaySound(clip, instance.soundFx);
	}
	
	public static void PlaySfx(string nameSound){
		if (instance == null) {
			Debug.Log ("No SoundManager found");
			return;
		}
		instance.PlaySound (nameSound, instance.sounds, instance.soundFx);
	}

	public static void PlayMusic(string nameMusic){
		if (instance == null) {
			Debug.Log ("No SoundManager found");
			return;
		}
		instance.PlaySound (nameMusic, instance.musics, instance.musicAudio);
	}

	private void PlaySound(string name, AudioClip[] pool, AudioSource audio){
		foreach (AudioClip clip in pool) {
			if (clip.name == name) {
				PlaySound (clip, audio);
				return;
			}
		}
		Debug.Log ("No audio found, check the name correctly");
	}

	private void PlaySound(AudioClip clip,AudioSource audioOut){
		audioOut.PlayOneShot (clip, SoundVolume);
	}
}
