using UnityEngine;
using System.Collections;

public class UIGameFail : MonoBehaviour {
	public AudioClip soundFail;
	// Use this for initialization
	void Start () {
		SoundManager.PlaySfx (soundFail);
	}
}
