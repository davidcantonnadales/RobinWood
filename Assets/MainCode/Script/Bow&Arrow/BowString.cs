using UnityEngine;
using System.Collections;

public class BowString : MonoBehaviour {
	public Transform pos1;
	public Transform pos2;
	public Transform pos3;

	private LineRenderer line1;
	private LineRenderer line2;
	private GameObject go1;
	private GameObject go2;

	// Use this for initialization
	void Start () {
		go1 = new GameObject ();
		go1.AddComponent<LineRenderer> ();
		line1 = go1.GetComponent<LineRenderer> ();
		line1.SetWidth (0.02f, 0.02f);
		go1.name = "Line1";

		go2 = new GameObject ();
		go2.AddComponent<LineRenderer> ();
		line2 = go2.GetComponent<LineRenderer> ();
		line2.SetWidth (0.02f, 0.02f);
		go2.name = "Line2";

	}
	
	// Update is called once per frame
	void Update () {
		line1.SetPosition (0, pos1.position);
		line1.SetPosition (1, pos2.position);
		line2.SetPosition (0, pos2.position);
		line2.SetPosition (1, pos3.position);
	}
}
