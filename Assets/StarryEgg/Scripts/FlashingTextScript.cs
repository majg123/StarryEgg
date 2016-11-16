using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FlashingTextScript : MonoBehaviour
{
	String thisDay;

	Text flashingText;
	string textToFlash = "Touch Screen";
	string blankText = "";
	string staticText = "Touch Screen";
	//flag to determine if you want the blinking to happen
	bool isBlinking = true;

	AsyncOperation async;
	bool isLoadGame = false;
	bool buttonClick = false;

	int touchCount=0;
	Touch touch;

	public IEnumerator LoadMain(){
		

		if (isLoadGame == false) {
			isLoadGame = true;
			while (!buttonClick) {
				//set the Text's text to blank
				flashingText.text = blankText;
				//display blank text for 0.5 seconds
				yield return new WaitForSeconds(.5f);
				//display “I AM FLASHING TEXT” for the next 0.5 seconds
				flashingText.text = textToFlash;
				yield return new WaitForSeconds(.5f);
			}
			Variables.newGame = PlayerPrefs.GetInt ("newGame", 0);
			if (Variables.newGame == 0) {
				Variables.curScene = 6;
			} else {
				Variables.curScene = 1;
			}
			async = SceneManager.LoadSceneAsync (Variables.curScene);

			while (async.isDone == false) {
				flashingText.text = "Loading...";
				yield return null;
				//yield return true;
			}
		}
	}

	void Start()
	{
		thisDay = DateTime.Today.ToString("d");

		if (!Variables.lastDay.Equals(thisDay)) {
			Variables.walkCount = 0;
			Variables.lastDay = thisDay;
			PlayerPrefs.SetString ("lastDay", Variables.lastDay);
			PlayerPrefs.SetInt ("walkCount", Variables.walkCount);
			PlayerPrefs.Save ();
		}

		flashingText = GetComponent<Text>();
		StartCoroutine(LoadMain());
		
		//get the Text component
		//Call coroutine BlinkText on Start
		//      StartCoroutine(BlinkText());
		//call function to check if it is time to stop the flashing.
		//       StartCoroutine(StopBlinking());
	}

	void Update (){
		touchCount = Input.touchCount;
	
		if (touchCount>0)
		{
			touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Ended) {
				buttonClick = true;
			}    
		}

		////////////////
		if(Input.GetMouseButtonDown (0)){
			buttonClick = true;
		}
	}

	/*   ///////////////////////////////////////////////
	//function to blink the text 
	public IEnumerator BlinkText()
	{
		//blink it forever. You can set a terminating condition depending upon your requirement. Here you can just set the isBlinking flag to false whenever you want the blinking to be stopped.
		while (isBlinking)
		{
			//set the Text's text to blank
			flashingText.text = blankText;
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			flashingText.text = textToFlash;
			yield return new WaitForSeconds(.5f);
		}
	}
	//your logic here. I have set the isBlinking flag to false after 5 seconds
	IEnumerator StopBlinking()
	{
		//wait for 5 seconds
		yield return new WaitForSeconds(5f);
		//stop the blinking
		isBlinking = false;
		//set a different text just for sake of clarity
		flashingText.text = staticText;
	}
	///////////////////////////////////////////////////////  */


}
