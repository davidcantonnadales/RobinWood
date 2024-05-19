using UnityEngine;
using System.Collections;

public class WindMill : MonoBehaviour {
	public bool DirectRight = true;
	public float speed = 40f;
	// Use this for initialization
	void Start () {
		if (!DirectRight)
			speed *= -1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward, speed * Time.deltaTime);
	}
}
