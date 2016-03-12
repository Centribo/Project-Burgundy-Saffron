using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public bool isGazedAt = false;
	public GameObject spawnPoint;
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
		GameManager.Instance.SetSolved(solvedRoom, true);
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : Color.white;
	}
}
