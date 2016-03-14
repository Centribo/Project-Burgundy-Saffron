using UnityEngine;
using System.Collections;

public class EndGameButtonController : MonoBehaviour {

	public bool isGazedAt = false;

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
		if(GameManager.Instance.GetReadyToFinish()){
			//End the game!
			GameManager.Instance.FinishGame();
		}
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isGazedAt ? new Color(0.1f, 0.1f, 0.1f) : originalColor;
	}

}
