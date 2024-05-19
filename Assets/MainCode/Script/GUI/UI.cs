using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	public Text levelName;
	public Text arrow;
	public Text score;

	// Use this for initialization
	void Start () {
		levelName.text = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		arrow.text = GameManager.arrowCurrent +"";
		score.text = GameManager.Score+"";
	}
}
