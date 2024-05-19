using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPick : MonoBehaviour {
	
	public Text levelText;
	public GameObject levelLocked;
	public GameObject levelStar;


	private bool available = false;
	private int levelNumber = 1;

	void Start () {
		//convert name to int
		levelNumber = int.Parse (gameObject.name);
		Setup ();
	}



	private void Setup(){
		//check what level did you complete
		int levelReached = PlayerPrefs.GetInt (GlobalValue.levelReached, 1);
		if (levelReached >= levelNumber)
			Reached ();
		else
			enabled = false;
	}


	private void Reached(){
		available = true;
		levelText.text = levelNumber + "";
		levelText.gameObject.SetActive (true);
		levelLocked.SetActive (false);

		//Check perfect 1: prefect, 0: not
		int perfect = PlayerPrefs.GetInt(GlobalValue.perfectLevel+levelNumber,0);
		if (perfect == 1) {
			levelStar.SetActive (true);
			GlobalValue.totalStarGot++;
		}

		//Get best score
		int highScore = PlayerPrefs.GetInt ("Lv "+levelNumber, 0);
		GlobalValue.totalScoreGot += highScore;
	}

	public void LoadLevel(){
		if (available) {
			SceneManager.LoadScene("Lv " + levelNumber);
		}
	}
}
