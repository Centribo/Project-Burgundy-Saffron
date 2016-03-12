using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public static GameManager Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (GameManager)FindObjectOfType(typeof(GameManager)); //Find it
			}
			return instance; //Return it
		}
	}

	public enum State {MainMenu, CountingDown, Playing}; //What state is the game in right now?

	//Public variables
	public State state = State.MainMenu;
	public int MaxTime; //Time that the players have to escape/win the game

	//Private variables
	DateTime initialTime;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
			case State.MainMenu:
				//Do nothing, most of this is handled in GUI events
			break;
			case State.CountingDown:
				GameObject.Find("CountdownText").GetComponent<Text>().text = "" + (10 - GetTime());
			break;
			case State.Playing:

			break;
		}
	}

	public void ResetTimer(){
		initialTime = DateTime.Now;
	}

	public int GetTimeRemaining(){ //Returns, in seconds, the time remaining before the players lose
		return MaxTime - GetTime();
	}

	public int GetTime(){ //Returns time, in seconds, since timer was started
		return DateTime.Now.Second - initialTime.Second;
	}

	public void StartPlayerA(){
		PlayerController.Instance.player = PlayerController.PlayerType.A;
		StartCountdown();
		GameObject.Find("HelpText").GetComponent<Text>().text = "Your objective is to help each other open the briefcase.\nLook and use the button to interact with objects.\nYou will be in the control room.";


		ResetTimer();
	}

	public void StartPlayerB(){
		PlayerController.Instance.player = PlayerController.PlayerType.B;
		StartCountdown();
		GameObject.Find("HelpText").GetComponent<Text>().text = "Your objective is to help each other open the briefcase.\nLook and use the button to interact with objects.\nYou will be in the room with the briefcase.";

		ResetTimer();
	}

	void StartCountdown(){
		Transform canvasParent = GameObject.Find("Canvas").transform;

		for(int i = canvasParent.childCount-1; i >= 0; i--){
			if(canvasParent.GetChild(i).name != "CountdownText"){
				if(canvasParent.GetChild(i).name == "HelpText"){
					canvasParent.GetChild(i).gameObject.SetActive(true);
				} else {
					canvasParent.GetChild(i).gameObject.SetActive(false);
				}
			}
		}

		ResetTimer();
		state = State.CountingDown;
	}

}
