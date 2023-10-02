using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIGASatanScript : SuperSatanScript
{
    public Color currentRegularColor;
    public Color attackColor1;
    public Color attackColor2;
    public Color attackColor3;
    public bool stopAllAttacks;
    // worrySpeed speeds up or slows down just about everything the boss does
    public float worrySpeed;
   
    public GameObject[] crabBeams;
    public GameObject[] firePlumes;

    // Start is called before the first frame update
    void Start()
    {
        //Load boss progress from saved data
        ProgressHandler.LoadProgressData();
        BossStage = ProgressHandler.GIGABossStage;

        //Start the fight immediately if it hasn't already
        if (!FightStarted) StartFight();
    }

    void StartFight()
    {
        FightStarted = true;
        // Set leg strength higher to make boss more fair
        foreach (CrabLeg leg in Legs)
        {
            leg.StrengthStrength = 2.6f;
        }

        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.SetActive(true);
        }
        // Set up flying and disable resets
        Spooky.Active = true;
        Spooky.Recharge = true;
        Spooky.ChargeMulti = FlightAmount;
        Spooky.DisableCameraChanges = true;
        progress.IgnoreControls = true;
        // Set the camera not to change
        ZoomFixer.enabled = true;
        ZoomFixer.CamZoom = 100f;
        // Set the attack speed multiplier to 1x
        worrySpeed = 1;
        // Begin the actual fight
        SatanScript.HasChaseStarted = true;
        StartCoroutine("BossFight");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator BossFight()
    {
        StartAttackLoops();
        yield return null;
    }

    IEnumerator DoRandomLargeAreaAttackLoop(float delay = 1f)
    {
        yield return new WaitForSeconds(delay * worrySpeed);
        while (!stopAllAttacks)
        {
            yield return new WaitForSeconds(Random.Range(6.05f, 16.25f) * worrySpeed);
            switch (Random.Range(0, 3))
            {
                case 0:
                    StartCoroutine("FirePlumeAttack");
                    break;
                case 1:
                    StartCoroutine("CrabKillingBeam");
                    break;
                case 2:
                    StartCoroutine("PianoDrop");
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator FirePlumeAttack()
    {
        // Select a random fire plume object and enable it
        firePlumes[Random.Range(0,firePlumes.Length)].SetActive(true);
        yield return null;
    }

    IEnumerator CrabKillingBeam()
    {
        // Select a random crab beam object and enable it
        crabBeams[Random.Range(0, crabBeams.Length)].SetActive(true);
        yield return null;
    }

    void StartAttackLoops()
    {
        // Start each attack according to the conditions
        if (!stopAllAttacks)
        {
            DoRandomLargeAreaAttackLoop(10f * worrySpeed);
        }
    }
}
