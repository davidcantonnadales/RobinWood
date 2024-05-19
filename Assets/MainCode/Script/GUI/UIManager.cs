using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public GameObject GameSuccess;
	public GameObject GameFail;
	public GameObject OutOfArrow;

	public static UIManager instiance;

	void Awake(){
		GameSuccess.SetActive (false);
		GameFail.SetActive (false);
		OutOfArrow.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		instiance = this;
	}

	public void ShowGameSuccess(){
		Destroy (GameFail);
		StartCoroutine (ShowGameUI (1.5f, GameSuccess));
	}
	public void ShowGameFail(){
		StartCoroutine (ShowGameUI (1.5f, GameFail));
	}
	public void ShowOutOfArrow(){
		StartCoroutine (ShowOutOfArrowDelay (0.5f));
	}


	IEnumerator ShowGameUI(float time, GameObject obj){
		yield return new WaitForSeconds (time);
		if (obj != null) {
			obj.SetActive (true);
		}
	}

	IEnumerator ShowOutOfArrowDelay(float time){
		yield return new WaitForSeconds (time);
		OutOfArrow.SetActive (true);
		ShowGameFail ();
	}

	public void RestartGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Home(){
		SceneManager.LoadScene ("Main Menu");
	}

	public void NextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
