using UnityEngine;
using System.Collections;

public class ExpUpAnim : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Variables.boolExp && Variables.mainSceneOn){
			anim.SetBool ("boolExpUp", true);
		}
	}

	void expUpFin(){
		anim.SetBool ("boolExpUp", false);
		Variables.boolExp = false;
	}

}
