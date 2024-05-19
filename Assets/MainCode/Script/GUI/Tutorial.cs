using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.anyKey || GameManager.instance.levelNumber != 1) {
			Destroy (gameObject);
		}
	}
}
