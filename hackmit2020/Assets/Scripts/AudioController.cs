using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public AudioSource BGM;

    public AudioClip menuBGM;
    public AudioClip levelBGM;

    private bool menuLoaded;
    private bool levelLoaded;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            menuLoaded = true;
            levelLoaded = false;
        }
        else
        {
            Destroy(gameObject); // If the build already has an Audio Source, destroy the new one
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1 && !levelLoaded) // Switch to levelBGM
        {
            BGM.Stop();
            BGM.clip = levelBGM;
            BGM.Play();
            levelLoaded = true;
            menuLoaded = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex <= 1 && !menuLoaded) // Switch to menuBGM
        {
            BGM.Stop();
            BGM.clip = menuBGM;
            BGM.Play();
            menuLoaded = true;
            levelLoaded = false;
        }
    }
}