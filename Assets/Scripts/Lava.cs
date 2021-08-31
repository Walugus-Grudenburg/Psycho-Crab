using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public bool IsDeadly;
    public AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProgressHandler Victim = collision.GetComponent<ProgressHandler>();
        if (Victim)
        {
            if (IsDeadly) 
            {
                Victim.Reset();
            }
            if (Sound)
            {
                Sound.Play();
            }
        }
    }
}
