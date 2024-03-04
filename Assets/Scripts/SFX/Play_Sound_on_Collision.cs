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
            // Make a temporary object to make the sound at the collision point
            GameObject soundObject = new GameObject("Audio Temp");
            soundObject.transform.position = collision.GetContact(0).point;
            AudioSource sound = soundObject.AddComponent<AudioSource>();

            // Copy settings from this object to the temporary one
            sound.spatialBlend = Hitsound.spatialBlend;
            sound.clip = Hitsound.clip;
            sound.dopplerLevel = Hitsound.dopplerLevel;
            sound.SetCustomCurve(AudioSourceCurveType.CustomRolloff, Hitsound.GetCustomCurve(AudioSourceCurveType.CustomRolloff));
            sound.priority = Hitsound.priority;
            sound.minDistance = Hitsound.minDistance;
            sound.maxDistance = Hitsound.maxDistance;
            
            if (!UseRandomMode) sound.volume = Mathf.Clamp(force / 4f, 0f, 1); // Sets the volume of the sound based on the velocity
            else if (UseRandomMode) sound.volume = Random.Range(minvolume,maxvolume);
            sound.pitch = Random.Range(minpitch, maxpitch); // Sets the pitch of the sound to random
            sound.Play();
            Destroy(soundObject, sound.clip.length);
            //Spawns a new object to play the sound
        }
    }
}
