using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingScene : MonoBehaviour {
	SpriteRenderer bell;
	public Image img;
	void Start(){
		
		//bell = GameObject.Find ("bell_btn").GetComponentInChildren<SpriteRenderer> ();
	
	}
	void Update(){
		if (!Variables.boolMute) {	
			img.sprite = Resources.Load<Sprite> ("bell_1");
		} else
			img.sprite = Resources.Load<Sprite> ("bell_0");
	}

	public void BellClick(){
		Variables.boolMute = !Variables.boolMute;

		if (Variables.boolMute)
			PlayerPrefs.SetInt ("Sound", 0);
		else
			PlayerPrefs.SetInt ("Sound", 1);
		
		PlayerPrefs.Save ();
	}
}
