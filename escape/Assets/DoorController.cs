using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool isGazedAt = false;

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

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? Color.yellow : Color.white;
	}
}
