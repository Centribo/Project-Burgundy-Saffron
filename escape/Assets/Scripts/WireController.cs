using UnityEngine;
using System.Collections;

public class WireController : MonoBehaviour {

	public int order; //What order we cut this wire in
	public int timing; //And what time on the clock we do so
	public bool isGazedAt = false;
	public Color originalColor;
	public bool isCut;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetGazedAt(bool gaze){
		isGazedAt = gaze;
		UpdateVisuals();
	}

	public void SetColor(Color c){
		GetComponent<Renderer>().material.color = c;
	}

	public void TryCut(){
		if(WireManager.Instance.CheckCut(order, timing)){
			GetComponent<CardboardAudioSource>().Play();
			isCut = true;
			UpdateVisuals();
			WireManager.Instance.CheckState();
		}
	}

	public void UpdateVisuals(){
		if(isCut){
			SetColor(Color.black);
		} else if(!isGazedAt){
			SetColor(originalColor);
		} else {
			SetColor(Color.yellow);
		}
	}
}
