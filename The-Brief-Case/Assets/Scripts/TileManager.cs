using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	public static TileManager instance = null;
	public static TileManager Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (TileManager)FindObjectOfType(typeof(TileManager)); //Find it
			}
			return instance; //Return it
		}
	}

	public GameObject tilePrefab;
	int[,] maze = new int[,] {
		{ 0, 0, 0, 8, 0 }, 
		{ 0, 0, 6, 7, 0 },
		{ 0, 4, 5, 0, 0 }, 
		{ 0, 3, 0, 0, 0 },
		{ 0, 2, 1, 0, 0 }
	}; //0 = invalid, other = order

	public int currentIndex = 0;
	float spacing = 1.2f;

	// Use this for initialization
	void Start () {
		SpawnMaze();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnMaze(){
		int width = maze.GetLength(0);
		int height = maze.GetLength(1);

		for(int x = 0; x < width; x++){
			for(int y = 0; y < height; y++){
				float xPos = transform.position.x + x*spacing;
				float zPos = transform.position.z + y*spacing;

				GameObject tileGO = (GameObject)Instantiate(tilePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
				tileGO.GetComponent<TileController>().tileIndex = maze[x, y];
				tileGO.name = "Tile (" + x + ", " + y + "): " + maze[x, y];
				tileGO.transform.SetParent(transform);
			}
		}
	}

	public bool ClickedCorrectTile(int indexClicked){
		if(indexClicked-1 == currentIndex){
			currentIndex++;
			return true;
		}
		return false;
	}

	public bool IsFinishedMaze(){
		if(currentIndex == 8){
			return true;
		}
		return false;
	}
}
