using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	public float speedMin = 0.005f;
	public float speedMax = 0.009f;

	private float speed;
	void Start(){
		speed = Random.Range (speedMin, speedMax)*(-1);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed, 0, 0));
	}

	void OnBecameInvisible() {
		transform.position = new Vector3 (7, transform.position.y, transform.position.z);
	}
}
