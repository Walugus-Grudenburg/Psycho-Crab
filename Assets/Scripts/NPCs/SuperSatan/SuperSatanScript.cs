using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSatanScript : MonoBehaviour
{
    public bool FightStarted;
    public float FlightAmount;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    public CrabLeg[] Legs;
    public GameObject[] ObjectsToActivate;
    public GameObject[] ObjectsToDestroy;
    public GameObject[] Anvils;
    public GameObject[] Anvils2;
    public GameObject[] Seagulls;
    public GameObject Swing1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartFight()
    {
        FightStarted = true;
        foreach (GameObject obj in ObjectsToDestroy)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.SetActive(true);
        }
        foreach (CrabLeg leg in Legs)
        {
            leg.StrengthStrength = 2.6f;
        }
        Spooky.Active = true;
        Spooky.Recharge = true;
        Spooky.ChargeMulti = FlightAmount;
        progress.IgnoreControls = true;
        ProgressHandler.DeTermination = false;
        SatanScript.HasChaseStarted = true;
        StartCoroutine("BossFight");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ProgressHandler.MoneyUnlocked && !FightStarted && collision.gameObject.CompareTag("Player"))
        {
            StartFight();
        }
    }

    IEnumerator BossFight()
    {
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(10f);
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(10f);
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(5f);
        StartCoroutine("AnvilAttack2");
        yield return new WaitForSeconds(5f);
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(5f);
        Swing1.SetActive(true);
        StartCoroutine("AnvilAttack2");
        yield return new WaitForSeconds(5f);
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(5f);
        Swing1.SetActive(true);
        StartCoroutine("AnvilAttack2");
        yield return new WaitForSeconds(6f);
        StartCoroutine("SeagullAttack");
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(5f);
        StartCoroutine("AnvilAttack2");
        yield return new WaitForSeconds(5f);
        Swing1.SetActive(true);
        StartCoroutine("AnvilAttack");
        yield return new WaitForSeconds(5f);
        StartCoroutine("AnvilAttack2");
    }

    IEnumerator AnvilAttack()
    {
        foreach (GameObject anvil in Anvils)
        {
            yield return new WaitForSeconds(1.5f);
            anvil.SetActive(true);
        }
    }

    IEnumerator AnvilAttack2()
    {
        foreach (GameObject anvil in Anvils2)
        {
            yield return new WaitForSeconds(1.3f);
            anvil.SetActive(true);
        }
    }

    IEnumerator SeagullAttack()
    {
        foreach (GameObject seagull in Seagulls)
        {
            yield return new WaitForSeconds(0.3f);
            seagull.SetActive(true);
        }
    }
}
