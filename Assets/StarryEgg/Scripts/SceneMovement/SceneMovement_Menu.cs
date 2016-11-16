using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Runtime.InteropServices;

public class SceneMovement_Menu : MonoBehaviour
{
	[DllImport("org.example.rotaryevent")]
	static extern bool setFalse();

	[DllImport("org.example.rotaryevent")]
	static extern bool getCounterClock();

    public AudioClip click;
    AudioSource clickAudio;

    public static SceneMovement_Menu instance;

    void Awake()
    {
        if (SceneMovement_Menu.instance == null)
            SceneMovement_Menu.instance = this;
    }

    void Start()
    {
		//setFalse ();
        clickAudio = GetComponent<AudioSource>();
    }

	void Update(){
	
		clickAudio.mute = Variables.boolMute;
		if (getCounterClock ()) {
			//SceneManager.UnloadScene(Variables.curScene);
			Variables.curScene=1;
			setFalse ();
			SceneManager.LoadScene (Variables.curScene);
		
		}		
	
	}
	public void HowtoClick(){
		Variables.curScene = 10;
		SceneManager.LoadScene(Variables.curScene);

	}
    public void bookClick()
    {

        clickAudio.PlayOneShot(click);
        Variables.curScene = 4;
        SceneManager.LoadScene(Variables.curScene);
    }

	public void setClick(){
		clickAudio.PlayOneShot(click);
		Variables.curScene = 7;
		SceneManager.LoadScene (Variables.curScene);
		
	}

	public void creditClick(){
		clickAudio.PlayOneShot (click);
		Variables.curScene = 9;
		SceneManager.LoadScene (Variables.curScene);
	}

}
