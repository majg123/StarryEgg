using UnityEngine;
using System.Collections;

public class BehaviorSceneOver : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Variables.behaviorSceneOn) {
			anim.SetBool ("sceneOn", true);
		} else {
			anim.SetBool ("sceneOn", false);
		}

	}
}
