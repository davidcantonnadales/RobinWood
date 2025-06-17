using UnityEngine;
using System.Collections;

public class ArrowTeleport : MonoBehaviour {

	public AudioClip soundTeleport;
	private BowManager Bow;
	private Animator anim;
	// Use this for initialization
	void Start () {
		Bow = FindObjectOfType<BowManager> ();
		anim = GetComponent<Animator> ();
	}

	//call by Arrow by send message
	public void Damage(){
		GetComponent<CircleCollider2D> ().enabled = false;
		SoundManager.PlaySfx (soundTeleport);
		Bow.transform.position = transform.position;
		anim.SetTrigger ("Effect");
	}

}
