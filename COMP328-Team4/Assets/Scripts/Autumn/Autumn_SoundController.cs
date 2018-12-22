using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autumn_SoundController : MonoBehaviour
{
    private AudioSource audio = new AudioSource();
    public AudioClip touch_sound;
    public AudioClip fail_sound;
    public AudioClip finish_sound;
    public AudioClip fever_sound;
    
    void Awake()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.loop = false;
    }

    public void Play_Touch_Sound()
    {
        this.audio.clip = this.touch_sound;
        this.audio.Play();
    }
    public void Play_Fail_Sound()
    {
        this.audio.clip = this.fail_sound;
        this.audio.Play();
    }
    public void Play_Finish_Sound()
    {
        this.audio.clip = this.finish_sound;
        this.audio.Play();
    }
    public void Play_Fever_Sound()
    {
        this.audio.clip = this.fever_sound;
        this.audio.Play();
    }
}
