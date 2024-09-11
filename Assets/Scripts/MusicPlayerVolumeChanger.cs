using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerVolumeChanger : MonoBehaviour
{
    AudioSource musicPlayer;
    public AudioSource voicePlayer;
    public Slider volumeSlider;
    public bool isVoicePlayer = false;
    public bool test;

    void Start()
    {
        if(!test)
        {
            musicPlayer = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSource>();
        } 
    }

    void FixedUpdate()
    {
        if (musicPlayer && !isVoicePlayer)
        {
            musicPlayer.volume = volumeSlider.value;
        }

        if (isVoicePlayer)
        {
            SetVoiceVolume();
        }
    }

    public void SetVoiceVolume()
    {
        if (musicPlayer)
        {
            voicePlayer.volume = musicPlayer.volume;
        }
    }
}
