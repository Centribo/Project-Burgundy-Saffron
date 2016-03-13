using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	public enum RoomType {Control, Briefcase, Maze, Wire, Riddle}; //Types of players

	//Public variables
	public RoomType roomType;
	public GameObject roomSpawnLocation; //Points to empty gameobject that represents where the player will spawn

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void MoveToRoom(){
		PlayerController.Instance.transform.position = roomSpawnLocation.transform.position;
	}
}
