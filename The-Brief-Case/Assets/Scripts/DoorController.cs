using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool isGazedAt = false;
	public GameObject spawnPoint;

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

	public void ClickDoor(){
		PlayerController.Instance.transform.position = spawnPoint.transform.position;
		GetComponent<CardboardAudioSource>().Play();
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : originalColor;
	}


}
