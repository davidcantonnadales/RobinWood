using UnityEngine;
using System.Collections;

public class ArrowHelper2 : MonoBehaviour {
	public bool rotate = false;
	public float speedRotate = 50f;
	public float fireForce = 850f;
	public GameObject arrow;
	private GameObject obj;
	private GameObject obj2;

	void Update(){
		if (rotate) {
			transform.Rotate (Vector3.forward, speedRotate * Time.deltaTime);
		}
	}

	public void Damage(){
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		obj =  Instantiate (arrow, transform.position, transform.localRotation) as GameObject;
		obj2 =  Instantiate (arrow, transform.position, transform.localRotation) as GameObject;
		obj2.transform.Rotate (Vector3.forward, 180f);
		//wait a moment to make sure 2 arrows just created already setup, then call Fire action
		StartCoroutine (WaitAndFire (0.05f));
	}

	IEnumerator WaitAndFire(float time){
		yield return new WaitForSeconds (time);
		obj.GetComponent<Arrow> ().Fire (fireForce);
		obj2.GetComponent<Arrow> ().Fire (fireForce);
		Destroy (gameObject);
	}
}
