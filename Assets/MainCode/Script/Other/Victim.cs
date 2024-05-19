using UnityEngine;
using System.Collections;

public class Victim : MonoBehaviour {
	public float timeToDie = 30f;
	public Transform TimerBar;
	public SpriteRenderer HeadObj;
	public Sprite headNormal;
	public Sprite headHit;
	public Sprite headSad;
	public Sprite headDead;
	public GameObject DeadPrefab;
	public int score = 500;

	public AudioClip[] soundGirl;

	private float health = 1f;
	private float reducePerSecond;
	private bool isDead = false;
	private bool isRescued = false;
	// Use this for initialization
	void Start () {
		reducePerSecond = health / timeToDie;
		StartCoroutine (Hurt (1));
	}

	IEnumerator Hurt(float time){
		yield return new WaitForSeconds (time);
		if (GameManager.CurrentState == GameManager.GameState.Playing) {
			health -= reducePerSecond;
		}
		CheckStatus ();
	}



	//Send Message from arrow hit the rope
	public void Rescued(){
		if (!isRescued) {
			isRescued = true;
			//add score
			GameManager.Score += (int)(score * health);
			StopAllCoroutines ();
			GameManager.Rescued ();
			TimerBar.gameObject.transform.parent.gameObject.SetActive (false);
			HeadObj.sprite = headNormal;
		}
	}

	public void Damage(){
		SoundManager.PlaySfx (soundGirl [Random.Range (0, soundGirl.Length)]);
		if (!isDead && !isRescued) {
			health -= 0.2f;
			CheckStatus ();
		}
	}

	private void Dead(){
		Instantiate (DeadPrefab,transform.position,Quaternion.identity);
		isDead = true;
		GameManager.Fail ();
	}

	private void CheckStatus(){
		health = Mathf.Clamp01 (health);
		TimerBar.localScale = new Vector3 (health, 1, 1);
		if (health <= 0) {
			GameManager.Fail ();
			Dead ();
			StopAllCoroutines ();
			return;
		} else if (health < 0.4f) {
			HeadObj.sprite = headSad;
		}
		else {
			HeadObj.sprite = headNormal;
		}

		StartCoroutine (Hurt (1));
	}
}
