using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BehaviorButton : MonoBehaviour {

	[SerializeField]
	private Text txt;

	[SerializeField]
	private Text ExpUp_Txt;

	[SerializeField]
	private Text GaugeDown_Txt;
    
    public AudioClip click;
    AudioSource clickAudio;
    public static BehaviorButton clickInstance;

    void Awake()
    {
        if (BehaviorButton.clickInstance == null)
        {
            BehaviorButton.clickInstance = this;
        }
    }

    void Start()
    {
        clickAudio = GetComponent<AudioSource>();
    }

    public void Sleep_Click(){
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 5400; // 2.5%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Stress = Mathf.Clamp(Variables.Stress - 5, 0, 100);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
        Variables.Satiety = Mathf.Clamp(Variables.Satiety - 15, 0, 100);
		PlayerPrefs.SetInt ("Satiety", Variables.Satiety);
		PlayerPrefs.Save();

		GaugeDown_Txt.text = "-2.5%";
		ExpUp_Txt.text = "+15%";

		Variables.SleepButton = true;
		Variables.behaviorSceneOn = false;
		Variables.mainSceneOn = true;

    }

	public void Book_Click(){
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 2808; // 1.3%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Intelligence = Mathf.Clamp(Variables.Intelligence + 5,0,100);
		PlayerPrefs.SetInt ("Intelligence", Variables.Intelligence);
        Variables.Stress = Mathf.Clamp(Variables.Stress + 5, 0, 100);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
		PlayerPrefs.Save ();

		GaugeDown_Txt.text = "-1.3%";
		ExpUp_Txt.text = "+5%";

        Variables.BookButton = true;
		Variables.behaviorSceneOn = false;
		Variables.mainSceneOn = true;
        
    }

	public void Eat_Click(){
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 3240; // 1.5%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Satiety = Mathf.Clamp(Variables.Satiety + 10,0,100);
		PlayerPrefs.SetInt ("Satiety", Variables.Satiety);
        Variables.Stress = Mathf.Clamp(Variables.Stress + 2, 0, 100);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
		PlayerPrefs.Save ();

		GaugeDown_Txt.text = "-1.5%";
		ExpUp_Txt.text = "+10%";

        Variables.EatButton = true;
		Variables.behaviorSceneOn = false;
		Variables.mainSceneOn = true;
        
    }

    public void Exercise_Click()
    {
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 4320; // 2%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Health = Mathf.Clamp(Variables.Health + 5, 0, 100);
		PlayerPrefs.SetInt ("Health", Variables.Health);
        Variables.Stress = Mathf.Clamp(Variables.Stress + 5, 0, 100);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
        Variables.Cleanliness = Mathf.Clamp(Variables.Cleanliness - 5, 0, 100);
		PlayerPrefs.SetInt ("Cleanliness", Variables.Cleanliness);
		PlayerPrefs.Save ();


        Variables.ExerciseButton = true;
        Variables.behaviorSceneOn = false;
        Variables.mainSceneOn = true;
        
    }

    public void Clean_Click()
    {
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 3240; // 1.5%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Cleanliness = Mathf.Clamp(Variables.Cleanliness + 5, 0, 100);
		PlayerPrefs.SetInt ("Cleanliness", Variables.Cleanliness);
        Variables.Stress = Mathf.Clamp(Variables.Stress + 5, 0, 100);
		PlayerPrefs.SetInt ("Stress", Variables.Stress);
		PlayerPrefs.Save ();


        Variables.CleanButton = true;
        Variables.behaviorSceneOn = false;
        Variables.mainSceneOn = true;
        
    }

    public void Play_Click()
    {
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        Variables.gauge -= 2160; // 1%씩 줄게
		PlayerPrefs.SetFloat ("Energy", Variables.gauge);
        Variables.Cleanliness = Mathf.Clamp(Variables.Cleanliness - 5, 0, 100);
		PlayerPrefs.SetInt ("Cleanliness", Variables.Cleanliness);
        Variables.Satiety = Mathf.Clamp(Variables.Satiety - 15, 0, 100);
		PlayerPrefs.SetInt ("Satiety", Variables.Satiety);
		PlayerPrefs.Save ();


        Variables.PlayButton = true;
        Variables.behaviorSceneOn = false;
        Variables.mainSceneOn = true;
        
    }

    public void TextButton_Click(){
		clickAudio.mute = Variables.boolMute;
        clickAudio.PlayOneShot(click);

        if (txt.text.Equals ("Sleeping")) {
			Sleep_Click ();
		} else if (txt.text.Equals ("Reading")) {
			Book_Click ();
		} else if (txt.text.Equals ("Eating")) {
			Eat_Click ();
		} else if (txt.text.Equals("Exercising")) {
            Exercise_Click();
        } else if (txt.text.Equals("Cleaning")) {
            Clean_Click();
        } else if (txt.text.Equals("Playing")) {
            Play_Click();
        }
    }
		
}
