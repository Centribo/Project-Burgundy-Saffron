using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	public Image imageToFade;
	public float fadeRate = 1.5f;
	public bool isFadingOut;
	public bool isFadingIn;

	// Use this for initialization
	void Start () {
		//imageToFade = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		HandleFading();
	}

	public void FadeToWhite(){
		isFadingOut = true;
	}

	public void FadeInFromWhite(){
		isFadingIn = true;
	}

	void HandleFading(){
		//Fade Out the screen to black
		if(isFadingOut){
			imageToFade.color = Color.Lerp(imageToFade.color, Color.white, fadeRate * Time.deltaTime);
			//Once the Black image is visible enough, Start loading the next level
			if(imageToFade.color.a >= 0.999){
				isFadingOut = false;
			}
		}

		if(isFadingIn){
			imageToFade.color = Color.Lerp(imageToFade.color, new Color(0,0,0,0), fadeRate * Time.deltaTime);
			if(imageToFade.color.a <= 0.01){
				isFadingIn = false;
			}
		}
	}
}
