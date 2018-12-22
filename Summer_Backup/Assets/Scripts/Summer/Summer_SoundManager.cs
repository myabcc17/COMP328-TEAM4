using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_SoundManager : MonoBehaviour {
    public AudioClip touch_sound;
    public AudioClip boost_sound;
    public AudioClip locked_sound;
    AudioSource myAudio;

    public static Summer_SoundManager instance;
    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
	}

    private void Awake()
    {
        if (Summer_SoundManager.instance == null)
            Summer_SoundManager.instance = this;
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void Play_Touch_Sound()
    {
        myAudio.PlayOneShot(touch_sound);
    }
    public void Play_Boost_Sound()
    {
        myAudio.PlayOneShot(boost_sound);
    }
    public void Play_Locked_Sound()
    {
        myAudio.PlayOneShot(locked_sound);
    }
}
