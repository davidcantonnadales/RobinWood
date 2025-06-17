using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public AudioClip fireSound;
	public AudioClip ropeSound;
	public AudioClip staticSound;
	
	private bool isFiring = false;
	private Rigidbody2D rig;
	private long GirlID;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
		rig.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring) {
			//Update rotate arrow with velocity x-y vector
			Vector2 vec = rig.velocity;
			float alpha = Mathf.Atan2 (vec.y, vec.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3 (0, 0, alpha);
		}
	}

	//action is sent from BowManager with force value
	public void Fire(float force){
		SoundManager.PlaySfx (fireSound);	
		rig.isKinematic = false;
		transform.parent = null;	
		isFiring = true;
		rig.AddRelativeForce (new Vector2 (force, 0), ForceMode2D.Force);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (isFiring) {
			//if hit any objects but static objects, send message Damage
			if (other.gameObject.CompareTag ("Girl")) {
				other.gameObject.transform.parent.SendMessage ("Damage", SendMessageOptions.DontRequireReceiver);

			} else if (other.gameObject.CompareTag ("Animal")) {
				other.gameObject.transform.SendMessage ("Damage", SendMessageOptions.DontRequireReceiver);

			} else {
				//try to send Damage to object
				other.gameObject.transform.SendMessage ("Damage", SendMessageOptions.DontRequireReceiver);
				SoundManager.PlaySfx (staticSound);
			}
			if (!other.gameObject.isStatic) {
				transform.SetParent (other.gameObject.transform);	//just set parent moving object, not static like wall, ground, tree,...
			}
			isFiring = false;
			rig.isKinematic = true;
			GetComponent<BoxCollider2D> ().enabled = false;
			GameManager.ArrowFinish (); //tell GameManager that arrow is stopped
			enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Rope")) {
			long ID = other.gameObject.transform.parent.GetInstanceID ();	//Get ID of Girl to make sure don't save her more than one time
			if (ID == GirlID)
				return;
			GirlID = ID;
			SoundManager.PlaySfx (ropeSound);
			other.gameObject.transform.parent.SendMessage ("Rescued", SendMessageOptions.DontRequireReceiver);	//send rescue action in Victim script
			other.gameObject.GetComponent<HingeJoint2D> ().enabled = false;
		} else if (other.gameObject.CompareTag ("Teleport")) {
			other.gameObject.transform.SendMessage ("Damage", SendMessageOptions.DontRequireReceiver);
			GameManager.ArrowFinish (); //tell Manager arrow finish firing
			Destroy (gameObject);
		} else {
			//try to send Damage to object
			other.gameObject.transform.SendMessage ("Damage", SendMessageOptions.DontRequireReceiver);
		}
	}
}
