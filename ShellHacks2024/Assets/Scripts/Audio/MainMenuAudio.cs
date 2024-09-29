using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private MusicLayerSystem mainMenueMusic;
    void Start()
    {
        mainMenueMusic = GetComponent<MusicLayerSystem>();
        mainMenueMusic.PlayMusic();
        
    }

    public void Increase()
    {
        mainMenueMusic.IncreaseMusicIntensity();
    }

    public void Decrease()
    {
        mainMenueMusic.DecreaseMusicIntensity();
    }

}
