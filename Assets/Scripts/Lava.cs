using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Lava : MonoBehaviour
{
    public bool IsDeadly;
    public AudioSource Sound;
    static int LavaDeathCount;
    // Start is called before the first frame update
    void Start()
    {
        SteamUserStats.GetStat("Deaths_Lava", out LavaDeathCount);
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
                LavaDeathCount++;
                SteamUserStats.SetStat("Deaths_Lava", LavaDeathCount);
                if (LavaDeathCount == 1)
                {
                    SteamUserStats.StoreStats();
                }
            }
            if (Sound)
            {
                Sound.Play();
            }
        }
    }
}
