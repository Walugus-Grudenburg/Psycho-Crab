using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static bool MusicEnabled = true;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (music == null)
        {
            music = gameObject.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        music.enabled = MusicEnabled;
    }

    public void ToggleMusic()
    {
        MusicEnabled = !MusicEnabled;
    }
}
