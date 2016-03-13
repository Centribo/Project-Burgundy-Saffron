using UnityEngine;
using System.Collections;

public class PasscodeController : MonoBehaviour {

	public static PasscodeController instance = null;
	public static PasscodeController Instance { //Singleton pattern instance
		get { //Getter
			if(instance == null){ //If its null,
				instance = (PasscodeController)FindObjectOfType(typeof(PasscodeController)); //Find it
			}
			return instance; //Return it
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnterDigit(int digit){

	}

	public void TryPasscode(){

	}
}
