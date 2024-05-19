using UnityEngine;
using System.Collections;

public class ArrowHelper : MonoBehaviour {
	public bool rotate = false;
	public float speedRotate = 50f;
	public float fireForce = 850f;
	public GameObject arrow;
	private GameObject obj;

	void Update(){
		if (rotate) {
			transform.Rotate (Vector3.forward, speedRotate * Time.deltaTime);
		}
	}

	//this action called by Arrow object
	public void Damage(){
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		obj =  Instantiate (arrow, transform.position, transform.localRotation) as GameObject;
		//wait a moment to make sure this arrow just created already setup, then call Fire action
		StartCoroutine (WaitAndFire (0.05f));
	}

	IEnumerator WaitAndFire(float time){
		yield return new WaitForSeconds (time);
		obj.GetComponent<Arrow> ().Fire (fireForce);
		Destroy (gameObject);
	}
}
