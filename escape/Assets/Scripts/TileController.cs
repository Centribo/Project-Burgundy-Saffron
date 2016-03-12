using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

	public int tileIndex;

	public bool isGazedAt = false;
	public bool isActivated = false;

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
		if(!isActivated){
			if(TileManager.Instance.ClickedCorrectTile(tileIndex)){
				isActivated = true;
				UpdateVisuals();
				PlayerController.Instance.transform.position = transform.position + Vector3.up * 2.0f;
			} else {
				GameManager.Instance.LoseGame();
			}
		} else {
			PlayerController.Instance.transform.position = transform.position + Vector3.up * 2.0f;
		}
		
	}

	public void UpdateVisuals(){
		if(isGazedAt){
			GetComponent<Renderer>().material.color = Color.yellow;
		} else {
			if(isActivated){
				GetComponent<Renderer>().material.color = Color.green;
			} else {
				GetComponent<Renderer>().material.color = Color.white;
			}
		}
	}
}
