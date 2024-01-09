using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip ArcadeMainTheme;

    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;

    void Start()
    {
        audioSourceMusic.clip = ArcadeMainTheme;
    }

    void Update()
    {
        if (!audioSourceMusic.isPlaying) {
            audioSourceMusic.Play();
        }
    }

    public void PlaySound(AudioClip sound)
    {
        audioSourceSound.clip = sound;
        audioSourceSound.Play();
    }
}
