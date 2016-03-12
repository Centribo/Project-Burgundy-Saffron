using UnityEngine;
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

	public enum State {MainMenu, Syncing, Playing}; //What state is the game in right now?

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

		ResetTimer();
	}

	public void StartPlayerB(){
		PlayerController.Instance.player = PlayerController.PlayerType.B;

		ResetTimer();
	}

	private void StartCountdown(){
		
	}

}
