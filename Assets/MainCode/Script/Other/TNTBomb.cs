using UnityEngine;
using System.Collections;

public class TNTBomb : MonoBehaviour {
	public AudioClip soundExplosion;
	public GameObject ExplosionFX;

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.CompareTag ("Player")) {
			//destroy arrow
			Destroy (other.collider.transform.gameObject);
			Damage ();
			return;
		}

		//check if the bomb falling
		float force = other.relativeVelocity.magnitude;
		//if the TNT Bomb get the impact strong enound, then Blow up
		if (force >= 5)
			Damage ();
	}

	void Damage(){
		SoundManager.PlaySfx (soundExplosion);
		GetComponent<SpriteRenderer> ().enabled = false;
		//Spawn a  bomb
		Instantiate (ExplosionFX, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
