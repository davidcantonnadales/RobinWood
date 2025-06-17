using UnityEngine;
using System.Collections;

public class BowManager : MonoBehaviour {
	
	public GameObject Arrow;
	[Tooltip("help touch and drag more easier")]
	public float mulDistaceDrag = 1.5f;
	public float arrowForce = 1800f;
	public Transform ArrowPoint;
	public Transform ArrowSpawnPoint;
	public Transform ArrowDirection;

	private float minLimited = -0.75f;
	private float maxLimited = -0.25f;
	private Vector2 pos1;
	private Vector2 pos2;
	private bool isDragging = false;
	private float distance;
	private GameObject arrow;

	// Use this for initialization
	void Start () {
		SpawnArrow ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.CurrentState == GameManager.GameState.Playing) {
			if (Input.GetButtonDown ("Fire1")) {
				isDragging = true;
				pos1 = Normal (Input.mousePosition);
			}
			if (Input.GetButtonUp ("Fire1")) {
				isDragging = false;
				ArrowPoint.localPosition = new Vector3 (maxLimited, 0, 0);
				ArrowDirection.localScale = new Vector3 (0, 1, 1);
				if (distance > 0.1f)
					Fire ();
			}
			if (isDragging) {
				pos2 = Normal (Input.mousePosition);
				distance = Vector2.Distance (pos1, pos2) * mulDistaceDrag;	//mul 1.5 time drag touch screen
				if (distance < 0.05f)
					return;

				//Rotate Bow
				float alpha = Mathf.Atan2 (pos1.y - pos2.y, pos1.x - pos2.x) * Mathf.Rad2Deg;
				transform.eulerAngles = new Vector3 (0, 0, alpha);

				//Drag
				float dragX = maxLimited - distance;
				dragX = Mathf.Clamp (dragX, minLimited, maxLimited);
				ArrowPoint.localPosition = new Vector3 (dragX, 0, 0);

				//Scale Direction
				float scaleDirection = Mathf.Clamp (distance, 0, 0.5f) * 2;
				ArrowDirection.localScale = new Vector3 (scaleDirection, 1, 1);
			}
		}
	}

	private Vector2 Normal(Vector2 vec2){
		Vector2 result;
		result.x = vec2.x / Screen.width;
		result.y = vec2.y / Screen.height;

		return result;
	}

	private void SpawnArrow(){
		arrow =  Instantiate (Arrow) as GameObject;
		arrow.transform.SetParent (ArrowSpawnPoint, false);
	}

	private void Fire(){
		if (GameManager.arrowCurrent <= 0)
			return;
		//reduce arrow
		GameManager.arrowCurrent--;

		float fireForce = Mathf.Clamp (distance, 0, 0.5f) * arrowForce;
		arrow.SendMessage ("Fire", fireForce, SendMessageOptions.DontRequireReceiver);

		//Check create new arrow
		if (GameManager.arrowCurrent > 0)
			StartCoroutine (CreateNextArrow (0.2f));
	}

	IEnumerator CreateNextArrow(float time){
		yield return new WaitForSeconds (time);
		SpawnArrow ();
	}
}
