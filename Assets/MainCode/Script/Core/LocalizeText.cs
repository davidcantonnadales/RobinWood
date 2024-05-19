using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour {

    public int ValueId;
    public bool ToUpper = false;
    public bool PreserveNumbers = false;
	// Use this for initialization
	void Start () {

        string numbers = "";

        if (PreserveNumbers)
        {
            numbers = Regex.Match(gameObject.GetComponent<Text>().text, @"\d+").Value;
        }

        gameObject.GetComponent<Text>().text = ToUpper ? Localization.Instance.GetValue(ValueId).ToUpper() : Localization.Instance.GetValue(ValueId);

        if(PreserveNumbers)
        {
            gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text + " " + numbers;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
