using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	Animator anim;

	//float speed = -1.0f;
   
	//Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Variables.mainSceneOn && Variables.SleepButton) {
			anim.SetBool ("Act_Sleep", true);
			Variables.SleepButton = false;       
        }


		if (Variables.mainSceneOn && Variables.EatButton) {
			anim.SetBool ("Act_Eat", true);
			Variables.EatButton = false;    
        }


		if (Variables.mainSceneOn && Variables.BookButton) {
			anim.SetBool ("Act_Book", true);
			Variables.BookButton = false;   
        }

	}
    
  

}
