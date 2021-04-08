using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource musicSource;
    [SerializeField] private AudioClip bgMusic;
    [SerializeField] private AudioClip slideFx;
    //[SerializeField] private AudioClip hit;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //subscribe to events
    }

    private void Start()
    {
        if(bgMusic != null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = bgMusic;
            musicSource.loop = true;
            musicSource.volume = 0.4f;
            PlayMusic();
        }
    }

    private void OnDisable()
    {
        
    }

    private void PlayMusic()
    {
        musicSource.Play();
    }
}
