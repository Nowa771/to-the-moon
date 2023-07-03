



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour 
{
    [Header("Sound")]
    public AudioSource uiClickSound;

    [Header("Music")]
    public AudioSource musicSource;
    public List<AudioClip> soundTracks;

    //Singleton
    public static AudioManager instance;

    //Variables
    private int currentSoundTrack;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(PlayMusic());
    }

    public void PlayAudioClip(AudioSource source)
    {
        source.Play();
    }

    private IEnumerator PlayMusic()
    {
        musicSource.clip = soundTracks[currentSoundTrack];
        musicSource.Play();
        currentSoundTrack++;
        if (currentSoundTrack >= soundTracks.Count)
            currentSoundTrack = 0;
        yield return new WaitUntil(() => musicSource.isPlaying == false);
        StartCoroutine(PlayMusic());
    }
}