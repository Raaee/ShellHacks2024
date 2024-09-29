using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using com.cyborgAssets.inspectorButtonPro;
using static System.TimeZoneInfo;

public class MusicLayerSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioStems;
    [SerializeField][Range(0.01f, 20f)] private float fadeInTime = 1.5f;
    [SerializeField][Range(0.01f, 20f)] private float fadeOutTime = 1.5f;
    [SerializeField] private AudioMixerGroup mixerGroup;

    private AudioSource[] audioSources;
    private int currentAudioSourceIntensity;
    private int amountOfStems;

    private const float MusicVolumeMax = .4f;
    private bool musicIsPlaying;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        musicIsPlaying = false;
        amountOfStems = audioStems.Length;

        if(amountOfStems <= 0)
        {
            Debug.LogError("No audio stems assigned to MusicLayerSystem");
            return;
        }
        audioSources = new AudioSource[amountOfStems];

        for(int i = 0; i< amountOfStems; i++)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();

            newAudioSource.playOnAwake = false;
            newAudioSource.loop = true;

            newAudioSource.clip = audioStems[i];

            if(mixerGroup != null)
            {
                newAudioSource.outputAudioMixerGroup = mixerGroup;
            }

            audioSources[i] = newAudioSource;
        }
    }

    [ProButton]
    public void PlayMusic()
    {
        if(musicIsPlaying)
        {
            return;
        }

        musicIsPlaying = true;

        audioSources[0].Play();

        StartCoroutine(FadeInMusicStem(audioSources[0], fadeInTime));

        for(int i = 1; i < audioSources.Length; i++)
        {
            audioSources[i].Play();
            audioSources[i].mute = true;
        }
        currentAudioSourceIntensity = 0;
    }
    [ProButton]
    public void StopMusic()
    {
        if(!musicIsPlaying)
        {
            return;
        }

        foreach(AudioSource audioSource in audioSources)
        {
            StartCoroutine(FadeOutMusicStem(audioSource, fadeOutTime));
        }
        StartCoroutine(StopMusicAfterFadeOut());

       
    }
    private IEnumerator StopMusicAfterFadeOut()
    {
        yield return new WaitForSeconds(fadeOutTime);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
        musicIsPlaying = false;
    }
    [ProButton]
    public void IncreaseMusicIntensity()
    {
        if (!musicIsPlaying)
        {
            return;
        }

        if (currentAudioSourceIntensity >= amountOfStems - 1)
        {
            return;
        }
        currentAudioSourceIntensity++;
        StartCoroutine(FadeInMusicStem(audioSources[currentAudioSourceIntensity], fadeInTime));


    }
    [ProButton]
    public void DecreaseMusicIntensity()
    {
        if (!musicIsPlaying)
        {
            return;
        }

        if (currentAudioSourceIntensity <= 0)
        {
            return;
        }
        StartCoroutine(FadeOutMusicStem(audioSources[currentAudioSourceIntensity], fadeOutTime));
        currentAudioSourceIntensity--;
    }

    private IEnumerator FadeInMusicStem(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0.0f;
        audioSource.mute = false;

        for (float t = 0.0f; t <= duration; t += Time.deltaTime)
        {
            audioSource.volume = (t / duration) * MusicVolumeMax;
            yield return null;
        }
        audioSource.volume = MusicVolumeMax;
    }

    private IEnumerator FadeOutMusicStem(AudioSource audioSource, float duration)
    {
        audioSource.volume = MusicVolumeMax;
        audioSource.mute = false;

        for (float t = 0.0f; t <= duration; t += Time.deltaTime)
        {
            audioSource.volume = (MusicVolumeMax - ((t / duration) * MusicVolumeMax));
            yield return null;
        }
        audioSource.volume = MusicVolumeMax;
    }
}
