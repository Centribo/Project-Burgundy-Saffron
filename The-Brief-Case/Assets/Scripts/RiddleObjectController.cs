using UnityEngine;
using System.Collections;

public class RiddleObjectController : MonoBehaviour {

	public bool isGazedAt = false;
	public bool isCorrectObject;
	public Room.RoomType solvedRoom;

	Color originalColor;

	// Use this for initialization
	void Start () {
		originalColor = GetComponent<Renderer>().material.color;
		UpdateVisuals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGazedAt(bool gaze){
		isGazedAt = gaze;
		UpdateVisuals();
	}

	public void ClickButton(){
		if(isCorrectObject){
			GameManager.Instance.SetSolved(solvedRoom, true);
			GetComponent<CardboardAudioSource>().Play();
		} else {
			GameManager.Instance.LoseGame();
		}
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : originalColor;
	}


}
