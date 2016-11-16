using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class collection_back : MonoBehaviour {

	public AudioClip click;
	AudioSource clickAudio;
	public static collection_back clickInstance;

	void Awake()
	{
		if (collection_back.clickInstance == null)
		{
			collection_back.clickInstance = this;
		}
	}

	void Start()
	{
		clickAudio = GetComponent<AudioSource>();
	}

    public void Click()
    {
		clickAudio.PlayOneShot (click);
		SceneManager.UnloadScene (Variables.curScene);
		if (Variables.newGame == 0) {
			Variables.curScene = 0;
		}
		else {
			Variables.curScene = 3;
		}
		SceneManager.LoadScene (Variables.curScene);
    }
}
