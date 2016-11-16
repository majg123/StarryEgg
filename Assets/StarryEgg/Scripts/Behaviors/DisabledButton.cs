using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class DisabledButton : MonoBehaviour {

	private Button btnEat,btnShower,btnPlaying,btnBook,btnExercise,btnSleeping,btnText;

	private void disabledButton()
	{
		if (Variables.evolvePhase == 1) {
			btnEat.interactable = false;
			btnShower.interactable = false;
			btnPlaying.interactable = false;
			btnBook.interactable = false;
			btnExercise.interactable = false;
			btnSleeping.interactable = false;
			btnText.interactable = false;

		} else {
			if (Variables.Stress >= 100) {
				btnEat.interactable = false;
				btnShower.interactable = false;
				btnPlaying.interactable = true;
				btnBook.interactable = false;
				btnExercise.interactable = false;
				btnSleeping.interactable = true;
			} else {
				if (Variables.gauge >= 5400) {
					btnEat.interactable = true;
					btnShower.interactable = true;
					btnPlaying.interactable = true;
					btnBook.interactable = true;
					btnExercise.interactable = true;
					btnSleeping.interactable = true;
				} else if (Variables.gauge < 5400 && Variables.gauge >= 4320) {
					btnSleeping.interactable = false;
					btnEat.interactable = true;
					btnShower.interactable = true;
					btnPlaying.interactable = true;
					btnBook.interactable = true;
					btnExercise.interactable = true;
				} else if (Variables.gauge < 4320 && Variables.gauge >= 3240) {
					btnExercise.interactable = false;
					btnEat.interactable = true;
					btnShower.interactable = true;
					btnPlaying.interactable = true;
					btnBook.interactable = true;
					btnSleeping.interactable = false;
				} else if (Variables.gauge < 3240 && Variables.gauge >= 2808) {
					btnExercise.interactable = false;
					btnSleeping.interactable = false;
					btnEat.interactable = false;
					btnShower.interactable = false;
					btnBook.interactable = true;
					btnPlaying.interactable = true;
				} else if (Variables.gauge < 2808 && Variables.gauge >= 2160) {
					btnExercise.interactable = false;
					btnSleeping.interactable = false;
					btnEat.interactable = false;
					btnShower.interactable = false;
					btnBook.interactable = false;
					btnPlaying.interactable = true;
				} else {
					btnExercise.interactable = false;
					btnSleeping.interactable = false;
					btnEat.interactable = false;
					btnShower.interactable = false;
					btnBook.interactable = false;
					btnPlaying.interactable = false;
				}
			}
			btnText.interactable = false;
		}
	}

	// Use this for initialization
	void Start () {
		btnEat = GameObject.Find("BtnEat").GetComponentInChildren<Button>();
		btnShower = GameObject.Find("BtnClean").GetComponentInChildren<Button>();
		btnPlaying = GameObject.Find("BtnPlaying").GetComponentInChildren<Button>();
		btnBook = GameObject.Find("BtnBook").GetComponentInChildren<Button>();
		btnExercise = GameObject.Find("BtnExercise").GetComponentInChildren<Button>();
		btnSleeping = GameObject.Find("BtnSleeping").GetComponentInChildren<Button>();
		btnText = GameObject.Find ("Action_Button").GetComponentInChildren<Button> ();
	}

	// Update is called once per frame
	void Update () {
		disabledButton();
	}
}