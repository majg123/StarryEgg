using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class SceneMovement_Walk : MonoBehaviour {


	[DllImport("org.example.rotaryevent")]
	static extern bool setFalse();

	[DllImport("org.example.rotaryevent")]
	static extern bool getClock();

	// Use this for initialization
	void Start () {
		//setFalse ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (getClock ()) {
			//SceneManager.UnloadScene (Variables.curScene);
			Variables.curScene=1;
			setFalse ();
			SceneManager.LoadScene (Variables.curScene);
		}
	}
}
