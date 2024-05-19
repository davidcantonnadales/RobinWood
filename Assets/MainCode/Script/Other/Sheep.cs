using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour {
	public Transform Tutorial;
	public AudioClip soundSheep;
	public float speed = 0.1f;
	private bool hited = false;
	private Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
		//if x scale = 1 mean the Sheep facing to Left
		//speed *= transform.localScale.x * 1;
		Tutorial.localScale = new Vector3 (transform.localScale.x, 1, 1);
	}

	void Update(){
		if (hited)
			transform.Translate (new Vector3 (speed, 0, 0));
	}

	public void Damage(){
		SoundManager.PlaySfx (soundSheep);
		hited = true;
		anim.SetBool ("Run", true);

		Tutorial.gameObject.SetActive (false);
	}
}
