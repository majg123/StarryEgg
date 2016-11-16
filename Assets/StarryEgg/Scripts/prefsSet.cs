using UnityEngine;
using System.Collections;

public class prefsSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Variables.newGame = PlayerPrefs.GetInt ("newGame", 0);

		Variables.lastDay = PlayerPrefs.GetString ("lastDay","2016-01-01");
		Variables.charType = PlayerPrefs.GetInt ("charType", 1);
		Variables.evolvePhase = PlayerPrefs.GetInt ("evolvePhase", 1);

		Variables.gauge = PlayerPrefs.GetFloat("Energy", 0);
		Variables.walkCount = PlayerPrefs.GetInt("walkCount", 0);
		Variables.exp = PlayerPrefs.GetInt ("Exp", 0);

		//Variables.newGame = PlayerPrefs.GetInt ("newGame", 0);

		Variables.Health = PlayerPrefs.GetInt("Health", 0);
		Variables.Cleanliness = PlayerPrefs.GetInt("Cleanliness", 0);
		Variables.Satiety = PlayerPrefs.GetInt("Satiety", 0);
		Variables.Stress = PlayerPrefs.GetInt("Stress", 0);
		Variables.Intelligence = PlayerPrefs.GetInt("Intelligence", 0);

		if (PlayerPrefs.GetInt ("Sound", 1) == 1)
			Variables.boolMute = false;
		else
			Variables.boolMute = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
