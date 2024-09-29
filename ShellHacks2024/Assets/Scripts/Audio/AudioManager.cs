using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

       
    }
    private IEnumerator FadeAudio(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        
        audioSource.volume = targetVolume;
    }

    public void FadeAudioToVolume(AudioSource audioSource, float transitionTime, float targetVolume)
    {
        StartCoroutine(FadeAudio(audioSource, transitionTime, targetVolume));
    }
    
    public void PlaySound(AudioSource audioSource, AudioClip clip)
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(clip);
    }

    
}
