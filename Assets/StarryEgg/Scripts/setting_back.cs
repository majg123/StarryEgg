using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class setting_back : MonoBehaviour {

	public AudioClip click;
	AudioSource clickAudio;
	public static setting_back clickInstance;

	void Awake()
	{
		if (setting_back.clickInstance == null)
		{
			setting_back.clickInstance = this;
		}
	}

	void Start()
	{
		clickAudio = GetComponent<AudioSource>();
	}
		
	public void Click(){
		clickAudio.PlayOneShot (click);
		Variables.curScene = 3;
		SceneManager.LoadScene (Variables.curScene);

	}
}
