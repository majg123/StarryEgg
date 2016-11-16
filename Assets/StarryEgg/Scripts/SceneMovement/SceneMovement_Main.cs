using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SceneMovement_Main : MonoBehaviour {

	[DllImport("org.example.rotaryevent")]
	static extern bool setFalse();

	[DllImport("org.example.rotaryevent")]
	static extern bool getCounterClock();

	[DllImport("org.example.rotaryevent")]
	static extern bool getClock();

	[DllImport("org.example.rotaryevent")]
	static extern void create_base_gui();



	int touchCount;
	Touch touch;
	float y0,y1,deltaY;

	Animator anim;

	void Start(){
		Variables.mainSceneOn = true;
		Variables.curScene = 1;
		create_base_gui ();

	}
	// Update is called once per frame
	void Update () {
		if (Variables.mainSceneOn) {
			if (getClock ()) {
				//SceneManager.UnloadScene (Variables.curScene);
				Variables.curScene=3;
				setFalse ();
				SceneManager.LoadScene (Variables.curScene);
			} else if (getCounterClock ()) {
				//SceneManager.UnloadScene (Variables.curScene);
				Variables.curScene=2;
				setFalse ();
				SceneManager.LoadScene (Variables.curScene);
			}
		}
	
		deltaY = 0;

		touchCount = Input.touchCount;

		if (touchCount > 0) {
			touch =Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {

				y0 = touch.position.y;
			}else if (touch.phase == TouchPhase.Ended) {
		
				y1 = touch.position.y;

				deltaY = y1 - y0;

				if (Variables.curScene==1 && deltaY > 60) {
					if ( Variables.mainSceneOn) {
							Variables.mainSceneOn = false;
							Variables.behaviorSceneOn = true;

					
						} else if (Variables.statSceneOn) {
							Variables.statSceneOn = false;
							Variables.mainSceneOn = true;
						}
				} else if (Variables.curScene==1 && deltaY < -60) {
						if (Variables.mainSceneOn) {
							Variables.mainSceneOn = false;
							Variables.statSceneOn = true;
						} else if (Variables.behaviorSceneOn) {
							Variables.behaviorSceneOn = false;
							Variables.mainSceneOn = true;
						}
					}


			}

		}
	
	}


}
