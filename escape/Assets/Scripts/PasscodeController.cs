using UnityEngine;
using UnityEngine.UI;
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

	readonly int[] PASSCODE = {6, 3, 9, 2};

	public Text passcodeText;
	public AudioClip pressFX;
	public AudioClip correctFX;
	public AudioClip incorrectFX;
	public bool isEntered = false;

	int currentIndex = 0;
	int[] currentAttempt = {0, 0, 0, 0};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnterDigit(int digit){
		if(!isEntered){
			if(currentIndex == 4){
				return;	
			}
			PlayButtonSound();
			currentAttempt[currentIndex] = digit;
			currentIndex ++;
			UpdatePasscodeText();
		}
	}

	public void UpdatePasscodeText(){
		passcodeText.text = "" + currentAttempt[0] + currentAttempt[1] + currentAttempt[2] + currentAttempt[3];
	}

	public void TryPasscode(){
		if(!isEntered){
			PlayButtonSound();
			currentIndex = 0;
			for(int i = 0; i < 4; i++){
				if(currentAttempt[i] != PASSCODE[i]){
					currentAttempt[0] = 0;
					currentAttempt[1] = 0;
					currentAttempt[2] = 0;
					currentAttempt[3] = 0;
					UpdatePasscodeText();
					PlayInCorrectSound();
					return;
				}
			}

			//If we get here, passcode is right
			passcodeText.color = Color.green;
			PlayCorrectSound();
			GameManager.Instance.SetReadyToFinish(true);
			isEntered = true;
		}
	}

	public void PlayButtonSound(){
		GetComponent<CardboardAudioSource>().clip = pressFX;
		GetComponent<CardboardAudioSource>().Play();
	}

	public void PlayCorrectSound(){
		GetComponent<CardboardAudioSource>().clip = correctFX;
		GetComponent<CardboardAudioSource>().Play();
	}

	public void PlayInCorrectSound(){
		GetComponent<CardboardAudioSource>().clip = incorrectFX;
		GetComponent<CardboardAudioSource>().Play();
	}
}
