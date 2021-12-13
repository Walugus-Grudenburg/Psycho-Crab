using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound_on_Collision : MonoBehaviour
{
    public float minforce;
    public float minpitch;
    public float maxpitch;
    public float minvolume;
    public float maxvolume;
    public bool UseRandomMode;
    public AudioSource Hitsound;
    void Start()
    {
        if (!Hitsound)
        {
            Hitsound = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Plays sound on collision
        float force = collision.relativeVelocity.magnitude;
        if (force > minforce) {
            if (!UseRandomMode) Hitsound.volume = Mathf.Clamp(force / 4f, 0f, 1); // Sets the volume of the sound based on the velocity
            else if (UseRandomMode) Hitsound.volume = Random.Range(minvolume,maxvolume);
            Hitsound.pitch = Random.Range(minpitch, maxpitch); // Sets the pitch of the sound to random
            Hitsound.Play();
        }
    }
}
