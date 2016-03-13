using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WireManager : MonoBehaviour {

	public List<WireController> wires;
	public Text clockText;

	int currentDigit; //What is our current digit?

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCurrentDigit();
		UpdateClockText();
	}

	void UpdateCurrentDigit(){
		currentDigit = Mod(GameManager.Instance.GetTimeRemaining(), 10) + 1;
	}

	void UpdateClockText(){
		clockText.text = "" + currentDigit;
	}

	int Mod(int n, int x){
		return ((n%x)+x)%x;
	}
}
