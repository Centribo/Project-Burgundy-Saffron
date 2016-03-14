using UnityEngine;
using System.Collections;

public class BriefcaseController : MonoBehaviour {

	public static BriefcaseController instance = null;
	public static BriefcaseController Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (BriefcaseController)FindObjectOfType(typeof(BriefcaseController)); //Find it
			}
			return instance; //Return it
		}
	}

	public enum LED { Maze, Wire, Riddle };

	public bool isOpened = false;
	public bool isGazedAt = false;
	public Mesh openedBriefcase;
	public LEDController mazeLED;
	public LEDController wireLED;
	public LEDController riddleLED;
	public AudioClip lockedFX;
	public AudioClip unlockedFX;
	public GameObject endGameButton;
	public GameObject endGameCanvas;

	Color originalColor;
	
	public void SetLED(LED led, bool isOn){
		switch(led){
			case LED.Maze:
				mazeLED.SetIsOn(isOn);
			break;
			case LED.Wire:
				wireLED.SetIsOn(isOn);
			break;
			case LED.Riddle:
				riddleLED.SetIsOn(isOn);
			break;
		}
	}

	public void SetGazedAt(bool gaze){
		isGazedAt = gaze;
		UpdateVisuals();
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : originalColor;
		if(isOpened){
			GetComponent<Renderer>().material.color = originalColor;
		}
	}

	public void TryOpenBriefcase(){
		if(GameManager.Instance.ArePuzzlesCompleted()){
			GetComponent<CardboardAudioSource>().clip = unlockedFX;
			GetComponent<CardboardAudioSource>().Play();
			OpenBriefcase();
		} else {
			GetComponent<CardboardAudioSource>().clip = lockedFX;
			GetComponent<CardboardAudioSource>().Play();
		}
	}

	public void OpenBriefcase(){
		if(!isOpened){
			GetComponent<MeshFilter>().mesh = openedBriefcase;
			GetComponent<MeshFilter>().sharedMesh = openedBriefcase;

			transform.position += 0.075f * Vector3.up;

			mazeLED.gameObject.SetActive(false);
			wireLED.gameObject.SetActive(false);
			riddleLED.gameObject.SetActive(false);
			GetComponent<MeshCollider>().enabled = false;
			GetComponent<CardboardAudioSource>().enabled = false;

			endGameButton.SetActive(true);
			endGameCanvas.SetActive(true);

			isOpened = true;
			GameManager.Instance.SetReadyToFinish(true);
			UpdateVisuals();
		}
	}

	// Use this for initialization
	void Start () {
		originalColor = GetComponent<Renderer>().material.color;
		UpdateVisuals();
	}
}
