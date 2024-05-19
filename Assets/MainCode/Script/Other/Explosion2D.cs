using UnityEngine;
using System.Collections;

public class Explosion2D : MonoBehaviour {
	public float explosionTimer = 0f;
	public float explosionRate = 1f;
	public float explosionSize = 2f;
	public float explosionForce = 500f;
	public float current_radius = 0f;
	public float explodeY = 2f;
	public float explodeX = 2f;
	bool exploded = false;

	//Collider2D explosion_radius;
	CircleCollider2D explosion_radius;

	// Use this for initialization
	void Start () {
		if (GetComponent<CircleCollider2D>() == null)
		{
			gameObject.AddComponent<CircleCollider2D>();
			GetComponent<Collider2D>().isTrigger = true;
		}
		explosion_radius = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		explosionTimer -= Time.deltaTime;
		if (explosionTimer < 0) {
			exploded = true;
		}
	}
	void FixedUpdate()
	{
		DoExplosion();
	}

	void DoExplosion()
	{
		if (exploded == true) {
			if (current_radius < explosionSize) {
				current_radius += explosionRate;
			} else {
				//disable scripts
				enabled = false;
				explosionForce = 0f;
			}

			explosion_radius.radius = current_radius;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (exploded == true) {
			if (col.gameObject.GetComponent<Rigidbody2D> () != null) {
				Vector2 target = col.gameObject.transform.position;
				Vector2 bomb = transform.position;

				Vector2 direction = explosionForce * (target - bomb);

				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (direction.x * explodeX, direction.y * explodeY));
			} else {
			}
		}
	}
}
