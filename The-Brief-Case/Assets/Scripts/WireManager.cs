using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WireManager : MonoBehaviour {

	public static WireManager instance = null;
	public static WireManager Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (WireManager)FindObjectOfType(typeof(WireManager)); //Find it
			}
			return instance; //Return it
		}
	}

	public List<WireController> wires;
	public Text clockText;

	// Cut order, Colour of wire, Time to cut
	// #1, Red, 9
	// #2, Blue, 1
	// #3, Green, 6
	// #4, White, 2

	int currentTimerDigit; //What is our current digit on the clock?
	int currentOrderDigit; //What wire # are we supposed to cut?

	// Use this for initialization
	void Start () {
		SetWires();
		currentOrderDigit = 0;
	}

	void SetWires(){
		bool[] isWireSet = new bool[wires.Count];
		for(int cutOrder = 0; cutOrder < wires.Count; cutOrder++){ //Start with the first rope to cut, choose which rope is that colour.
			int displayOrder = Random.Range(0, wires.Count);
			while(isWireSet[displayOrder]){
				displayOrder = Random.Range(0, wires.Count);
			}

			if(cutOrder == 0){ //Red, 9
				wires[displayOrder].SetColor(Color.red);
				wires[displayOrder].originalColor = Color.red;
				wires[displayOrder].order = 0;
				wires[displayOrder].timing = 9;
			} else if(cutOrder == 1){ //Blue, 1
				wires[displayOrder].SetColor(Color.blue);
				wires[displayOrder].originalColor = Color.blue;
				wires[displayOrder].order = 1;
				wires[displayOrder].timing = 1;
			} else if(cutOrder == 2){ //Green, 6
				wires[displayOrder].SetColor(Color.green);
				wires[displayOrder].originalColor = Color.green;
				wires[displayOrder].order = 2;
				wires[displayOrder].timing = 6;
			} else if(cutOrder == 3){ //White, 4
				wires[displayOrder].SetColor(Color.white);
				wires[displayOrder].originalColor = Color.white;
				wires[displayOrder].order = 3;
				wires[displayOrder].timing = 2;
			}

			isWireSet[displayOrder] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCurrentTimerDigit();
		UpdateClockText();
	}

	void UpdateCurrentTimerDigit(){
		currentTimerDigit = Mod(GameManager.Instance.GetTimeRemaining(), 10) + 1;
	}

	void UpdateClockText(){
		clockText.text = "" + currentTimerDigit;
	}

	public void CheckState(){
		for(int i = 0; i < wires.Count; i++){
			if(!wires[i].isCut){
				return; //Exits if we find a wire that hasn't be cut
			}
		}

		GetComponent<CardboardAudioSource>().Play();
		GameManager.Instance.SetSolved(Room.RoomType.Wire, true);
	}

	public bool CheckCut(int order, int timing){
		if(order == currentOrderDigit && timing == currentTimerDigit){
			currentOrderDigit ++;
			return true;
		}
		return false;
	}

	int Mod(int n, int x){
		return ((n%x)+x)%x;
	}
}
