using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	public Transform pos1;
	public Transform pos2;
	public float speed = 2f;
	public AudioClip deadSound;
	private bool MoveRight = true;
	private bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDead) {
			if (MoveRight) {
				//scale facing right
				transform.localScale = new Vector3 (1, 1, 1);
				transform.position = Vector3.MoveTowards (transform.position, pos2.position, speed * Time.deltaTime);
				if (Vector3.Magnitude (transform.position - pos2.position) < 0.1f)
					MoveRight = false;
			} else {
				//scale facing left
				transform.localScale = new Vector3 (-1, 1, 1);
				transform.position = Vector3.MoveTowards (transform.position, pos1.position, speed * Time.deltaTime);
				if (Vector3.Magnitude (transform.position - pos1.position) < 0.1f)
					MoveRight = true;
			}
		}
	}

	//sent by arrow
	public void Damage(){
//		if (!deadSound)
			SoundManager.PlaySfx (deadSound);
		isDead = true;
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<Animator> ().enabled = false;
		StartCoroutine (Wait (0.1f));

	}

	IEnumerator Wait(float time){
		yield return new WaitForSeconds (time);
		GetComponent<Rigidbody2D> ().gravityScale = 1;
		enabled = false;
	}
}
