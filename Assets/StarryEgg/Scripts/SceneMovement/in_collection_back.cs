using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class in_collection_back : MonoBehaviour {

	public AudioClip click;
	AudioSource clickAudio;
	public static in_collection_back clickInstance;

	void Awake()
	{
		if (in_collection_back.clickInstance == null)
		{
			in_collection_back.clickInstance = this;
		}
	}

	void Start()
	{
		clickAudio = GetComponent<AudioSource>();
	}


    public void Click()
    {
		clickAudio.PlayOneShot (click);
		Variables.curScene = 4;
		SceneManager.LoadScene(Variables.curScene);
    }
}
