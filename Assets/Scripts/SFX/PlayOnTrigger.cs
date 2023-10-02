using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour
{
    public AudioSource SoundToPlay;
    public bool playersOnly;
    // Start is called before the first frame update
    void Start()
    {
        if (!SoundToPlay) SoundToPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playersOnly || collision.CompareTag("Player"))
        {
            if (!SoundToPlay.isPlaying)
            {
                SoundToPlay.Play();
            }
        }
    }
}
