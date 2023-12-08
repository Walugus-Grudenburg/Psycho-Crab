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
        if (IsDeadly & RoboCrabScript.mainInstance)
        {
            float distanceToRoboCrab = Vector3.Distance(gameObject.transform.position, RoboCrabScript.mainInstance.gameObject.transform.position);
            if (RoboCrabScript.nearestLavaDistance > distanceToRoboCrab)
            {
                RoboCrabScript.nearestLavaDistance = distanceToRoboCrab;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProgressHandler Victim = collision.GetComponent<ProgressHandler>();
        if (Victim)
        {
            if (IsDeadly && !OilFire.hasFireStarted) 
            {
                Victim.Reset();
                if (!ProgressHandler.DeTermination)
                {
                    LavaDeathCount++;
                    SteamUserStats.SetStat("Deaths_Lava", LavaDeathCount);
                    if (LavaDeathCount == 1)
                    {
                        SteamUserStats.StoreStats();
                    }
                }
            }
            if (Sound)
            {
                Sound.Play();
            }
        }
        else if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ProgressHandler Victim = collision.GetComponent<ProgressHandler>();
        if (Victim)
        {
            if (IsDeadly && !OilFire.hasFireStarted)
            {
                Victim.Reset();
                if (!ProgressHandler.DeTermination)
                {
                    LavaDeathCount++;
                    SteamUserStats.SetStat("Deaths_Lava", LavaDeathCount);
                    if (LavaDeathCount == 1)
                    {
                        SteamUserStats.StoreStats();
                    }
                    if (Sound)
                    {
                        Sound.Play();
                    }
                }
            }
        }
        else if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
