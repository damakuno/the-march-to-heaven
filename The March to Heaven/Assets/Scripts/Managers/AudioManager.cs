using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;
    [Header("Audio Sources")]
    [SerializeField]
    AudioSource bgmSource;
    [SerializeField]
    AudioSource sfxSource, voiceSource;

    [Header("Background Music")]
    [SerializeField]
    AudioClip defaultBGM;
    [Header("Sound Effects")]
    [SerializeField]
    AudioClip buttonSFX;

    const int MIN_VOL = -60;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource.clip = defaultBGM;
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBGMVolume(float volume)
    {
        mixer.SetFloat("bgmVol", MIN_VOL * (1 - volume));
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("sfxVol", MIN_VOL * (1 - volume));
    }
}
