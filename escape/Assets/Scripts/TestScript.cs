using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(GameObject.Find("Head").GetComponent<CardboardHead>().Gaze);
		Debug.Log(Cardboard.SDK.Triggered);
	}
}
