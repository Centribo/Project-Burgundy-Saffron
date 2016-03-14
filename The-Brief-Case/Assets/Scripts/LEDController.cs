using UnityEngine;
using System.Collections;

public class LEDController : MonoBehaviour {

	public bool isOn = false;

	// Use this for initialization
	void Start () {
		UpdateVisuals();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetIsOn(bool isOn){
		this.isOn = isOn;
		UpdateVisuals();
	}

	public void FlipLED(){
		isOn = !isOn;
		UpdateVisuals();
	}

	public void UpdateVisuals(){
		GetComponent<Renderer>().material.color = isOn ? Color.green : Color.red;
	}
}
