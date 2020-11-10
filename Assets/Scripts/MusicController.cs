using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    private AudioSource backgroundAudio;
    private GameManager gameManager;

    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(!gameManager.isGameActive)
        {
            // start music
            backgroundAudio.mute = true;

        } else
        {
            // stop music 
            backgroundAudio.mute = false;
        }
    }
}
