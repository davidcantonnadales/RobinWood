using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIGameSuccess : MonoBehaviour {
	public AudioClip soundShowUp;
	public Text scoreLabel;
	public Text bestLabel;
	public GameObject perfectStar;
	// Use this for initialization
	void Start () {
		SoundManager.PlaySfx (soundShowUp);
		scoreLabel.text = GameManager.Score + "";
		bestLabel.text = GameManager.HighScore + "";
		if (GameManager.isPerfect)
			StartCoroutine (ShowPerfectStarDelay (1));
	}
	
	IEnumerator ShowPerfectStarDelay(float time){
		yield return new WaitForSeconds (time);
		perfectStar.SetActive (true);
	}
}
