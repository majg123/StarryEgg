using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class change_characters : MonoBehaviour {

   	Animator anim;
	SpriteRenderer spr;
	BoxCollider2D bc;
	[SerializeField]
	private Sprite a1, a2, a3, a4;

	[SerializeField]
	private GameObject levelUp;

//	public Scene sc;

	void Awake(){
		//levelUp = GameObject.Find ("levelUp");
		levelUp.SetActive (false);
	}


	void Start (){
		bc = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();
		spr = GetComponent<SpriteRenderer> ();

		switch (Variables.evolvePhase) {
		case 1: //egg
			bc.enabled = true;
			spr.sprite = a1;
			anim.SetLayerWeight (0, 1.0f);
			break;
		case 2:
			bc.enabled = false;
			spr.sprite = a2;
			anim.SetLayerWeight (1, 1.0f);
			break;
		case 3:
			bc.enabled = false;
			spr.sprite = a3;
			anim.SetLayerWeight (2, 1.0f);
			break;
		case 4:
			bc.enabled = false;
			spr.sprite = a4;
			anim.SetLayerWeight (3, 1.0f);
			break;
		case 5:
			bc.enabled = false;
			anim.SetLayerWeight (4, 1.0f);
			break;
		case 6:
			bc.enabled = false;
			anim.SetLayerWeight (5, 1.0f);
			break;
		}
			
	}     

	// Update is called once per frame
	void Update () {

		if (Variables.mainSceneOn) {
			if (Variables.SleepButton) {
				anim.SetBool ("Act_Sleep", true);
				Variables.SleepButton = false;       
			}

			if (Variables.EatButton) {
				anim.SetBool ("Act_Eat", true);
				Variables.EatButton = false;    
			}

			if (Variables.BookButton) {
				anim.SetBool ("Act_Book", true);
				Variables.BookButton = false;   
			}

			if (Variables.ExerciseButton) {
				anim.SetBool ("Act_Exercise", true);
				Variables.ExerciseButton = false;   
			}

			if (Variables.CleanButton) {
				anim.SetBool ("Act_Clean", true);
				Variables.CleanButton = false;   
			}

			if (Variables.PlayButton) {
				anim.SetBool ("Act_Play", true);
				Variables.PlayButton = false;   
			}
		}

		Evolve ();
	}

	void Evolve(){
		if (Variables.evolving) {
			switch (Variables.evolvePhase) {	//after evlovePhase Up
		/*	case 1: //egg -> evolve
				bc.enabled = true;
				spr.sprite = a1;
				anim.SetLayerWeight (0, 1.0f);
				Variables.evolving = false;
				break;			*/
			case 2:    ////☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
				bc.enabled = false;

				spr.sprite = a2;
				anim.SetLayerWeight (0, 0f);
				anim.SetLayerWeight (1, 1.0f);
				Variables.evolving = false;
				break;
			case 3:
				bc.enabled = false;
				spr.sprite = a3;
				anim.SetLayerWeight (1, 0f);
				anim.SetLayerWeight (2, 1.0f);
				Variables.evolving = false;
				break;
			case 4: 
				bc.enabled = false;
				spr.sprite = a4;
				anim.SetLayerWeight (2, 0f);
				anim.SetLayerWeight (3, 1.0f);
				Variables.evolving = false;
				break;
			case 5:
				bc.enabled = false;
				anim.SetLayerWeight (1, 0f);
				anim.SetLayerWeight (4, 1.0f);
				Variables.evolving = false;
				break;
			case 6:  
				bc.enabled = false;
				anim.SetLayerWeight (4, 0f);
				anim.SetLayerWeight (5, 1.0f);
				Variables.evolving = false;
				break;
			default:
				Variables.evolving = false;
				break;
			}
			if(!Variables.isEnding){
				StartCoroutine(levelUpScene());
			}
		}
	}

	IEnumerator levelUpScene(){
				levelUp.SetActive (true);
				yield return new WaitForSeconds (1.5f);
				levelUp.SetActive (false);	
	}



	void SleepFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Sleep", false);
	}

	void EatFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Eat", false);
	}

	void BookFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Book", false);
	}

	void CleanFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Clean", false);
	}

	void PlayFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Play", false);
	}

	void ExerciseFin(){
		Variables.boolExp = true;
		anim.SetBool ("Act_Exercise", false);
	}

}
