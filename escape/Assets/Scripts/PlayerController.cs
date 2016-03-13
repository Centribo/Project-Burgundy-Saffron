using UnityEngine;
using UnityEngine.UI;
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
	public Room.RoomType currentRoom;

	public GameObject screenFadingCanvas;
	public float fadeRate = 1.5f;
	public bool isFadingOut;
	public bool isFadingIn;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		screenFadingCanvas.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HandleFading();
	}

	public void FadeToWhite(){
		screenFadingCanvas.SetActive(true);
		isFadingOut = true;
	}

	public void FadeInFromWhite(){
		isFadingIn = true;
	}

	void OnLevelWasLoaded(int level){
		FadeInFromWhite();
	}

	void HandleFading(){
		//Fade Out the screen to black
		if(isFadingOut){
			screenFadingCanvas.GetComponent<Image>().color = Color.Lerp(screenFadingCanvas.GetComponent<Image>().color, Color.white, fadeRate * Time.deltaTime);
			//Once the Black image is visible enough, Start loading the next level
			if(screenFadingCanvas.GetComponent<Image>().color.a >= 0.999){
				isFadingOut = false;
			}
		}

		if(isFadingIn){
			screenFadingCanvas.GetComponent<Image>().color = Color.Lerp(screenFadingCanvas.GetComponent<Image>().color, new Color(0,0,0,0), fadeRate * Time.deltaTime);
			if(screenFadingCanvas.GetComponent<Image>().color.a <= 0.01){
				isFadingIn = false;
				screenFadingCanvas.SetActive(false);
			}
		}
	}
}
