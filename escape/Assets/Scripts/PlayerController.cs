using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance = null;
	public static PlayerController Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (PlayerController)FindObjectOfType(typeof(PlayerController)); //Find it
			}
			return instance; //Return it
		}
	}

	public enum PlayerType {A, B}; //Types of players

	//Public variables
	
	public PlayerType player;



	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
