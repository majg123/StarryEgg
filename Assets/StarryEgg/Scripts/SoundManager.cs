using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip[] bgm;
    AudioSource bgmAudio;

    public static SoundManager instance;

    static bool AudioBegin = false;

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;

        bgmAudio = GetComponent<AudioSource>();

        if (!AudioBegin)
        {
            bgmAudio.clip = bgm[Random.Range(0, 2)];
			bgmAudio.loop = true;
            bgmAudio.Play();

			bgmAudio.volume = 0.4f; //0.0 f~ 1.0f
            DontDestroyOnLoad(bgmAudio);
            AudioBegin = true;
        }
    }
    
    
    void Update()
    {/*
        if (Application.loadedLevelName == "Upgraded")
        {
            audio.Stop();
            AudioBegin = false;
        }
        */

		bgmAudio.mute = Variables.boolMute;
    }
    
}
