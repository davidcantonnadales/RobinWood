using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelChoose : MonoBehaviour {
	public GameObject UI;
	public GameObject Environment;
	public Transform Level;
	public float limitedLeft = -38.4f;
	public float limitedRight = 0f;
	public Text totalScoreText;
	public Text totalStarText;

	private float step = 12.8f;
	private bool moving = false;
	private float desX;
	// Use this for initialization
	void Awake(){
		//reset global value
		GlobalValue.totalStarGot = 0;
		GlobalValue.totalScoreGot = 0;
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			Level.transform.position = Vector3.Lerp (Level.transform.position, new Vector3 (desX, 0, 0), 10 * Time.deltaTime);
			if (Mathf.Abs (Level.transform.position.x - desX) < 0.1f) {
				Level.transform.position = new Vector3 (desX, 0, 0);
				moving = false;
			}
		}

		//set total star got
		totalStarText.text = GlobalValue.totalStarGot + "/35";
		totalScoreText.text = GlobalValue.totalScoreGot + "";
	}

	public void Next ()
	{
		if (!moving) {
			desX = Level.transform.position.x - step;
			desX = Mathf.Clamp (desX, limitedLeft, limitedRight);
			moving = true;	//allow moving
		}
	}

	public void Previous ()
	{
		if (!moving) {
			desX = Level.transform.position.x + step;
			desX = Mathf.Clamp (desX, limitedLeft, limitedRight);
			moving = true;	//allow moving
		}
	}

	public void Back(){
		UI.SetActive (true);
		Environment.SetActive (true);
		gameObject.SetActive (false);
	}
}
