using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Lava : MonoBehaviour
{
    public bool IsDeadly;
    public bool alwaysKills;
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
        CheckLavaKill(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckLavaKill(collision);
    }

    void CheckLavaKill(Collider2D victimcollider)
    {
        ProgressHandler Victim = victimcollider.GetComponent<ProgressHandler>();
        if (Victim)
        {
            LavaKill(Victim);
        }
        else if (victimcollider.CompareTag("Collectable"))
        {
            Destroy(victimcollider.gameObject);
        }
    }

    void LavaKill(ProgressHandler Victim)
    {
        if (IsDeadly && alwaysKills)
        {
            Victim.Reset(true);
        }
        else if (IsDeadly && !OilFire.hasFireStarted)
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
}
