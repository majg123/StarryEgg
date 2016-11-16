using UnityEngine;
using System.Collections;

public class StatSceneOver : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Variables.statSceneOn) {
			anim.SetBool ("sceneOn", true);
		} else {
			anim.SetBool ("sceneOn", false);
		}

	}
}
