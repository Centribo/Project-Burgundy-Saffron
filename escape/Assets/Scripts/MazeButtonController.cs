using UnityEngine;
using System.Collections;

public class MazeButtonController : MonoBehaviour {

	public bool isGazedAt = false;
	public Room.RoomType solvedRoom;

	// Use this for initialization
	void Start () {
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
		if(TileManager.Instance.IsFinishedMaze()){
			GameManager.Instance.SetSolved(solvedRoom, true);
			GetComponent<CardboardAudioSource>().Play();
		}
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : Color.white;
	}
}
