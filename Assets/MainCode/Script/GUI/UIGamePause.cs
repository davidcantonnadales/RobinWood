using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIGamePause : MonoBehaviour {
	public GameObject Dark;
	public Sprite PauseButtonUp;
	public Sprite PauseButtonDown;
	public Image buttonPause;

	public Image SoundBut;
	public Image MusicBut;
	public Sprite SoundOn;
	public Sprite SoundOff;
	public Sprite MusicOn;
	public Sprite MusicOff;

	private Animator anim;
	private bool isPause = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		//init state SOund and MUsic button
		if (GlobalValue.isSound) {
			SoundBut.sprite = SoundOn;
		}else{
			SoundBut.sprite = SoundOff;
		}

		if (GlobalValue.isMusic) {
			MusicBut.sprite = MusicOn;

		}else{
			MusicBut.sprite = MusicOff;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Pause ();
	}

	public void Pause(){
		isPause = !isPause;
		if (isPause) {
			GameManager.instance.state = GameManager.GameState.Pause;
			Dark.SetActive (true);
			anim.SetTrigger ("Move In");
			buttonPause.sprite = PauseButtonUp;
		} else {
			GameManager.instance.state = GameManager.GameState.Playing;
			Dark.SetActive (false);
			anim.SetTrigger ("Move Out");
			buttonPause.sprite = PauseButtonDown;
		}
	}

	public void Sound(){
		GlobalValue.isSound = !GlobalValue.isSound;
		if (GlobalValue.isSound) {
			SoundManager.SoundVolume = 1f;
			SoundBut.sprite = SoundOn;
		}else{
			SoundManager.SoundVolume = 0f;
			SoundBut.sprite = SoundOff;
		}
	}

	public void Music(){
		GlobalValue.isMusic = !GlobalValue.isMusic;
		if (GlobalValue.isMusic) {
			MusicBut.sprite = MusicOn;
			SoundManager.MusicVolume = 1f;

		}else{
			MusicBut.sprite = MusicOff;
			SoundManager.MusicVolume = 0f;
		}
	}
}
