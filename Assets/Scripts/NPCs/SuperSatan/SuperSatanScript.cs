using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSatanScript : MonoBehaviour
{
    public static int BossStage;
    public bool FightStarted;
    public float FlightAmount;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    public CrabLeg[] Legs;
    public GameObject[] ObjectsToActivate;
    public GameObject[] ObjectsToDestroy;
    public GameObject[] Anvils;
    public GameObject[] Anvils2;
    public GameObject[] Anvils3;
    public GameObject[] Seagulls;
    public GameObject[] Waypoints;
    public GameObject[] Arenas;
    public GameObject Swing1;
    public GameObject BCP;
    public Follow_Position Camera;
    public CameraZoomFixer ZoomFixer;

    // Start is called before the first frame update
    void Start()
    {
        ProgressHandler.LoadProgressData();
        BossStage = ProgressHandler.BossStage;
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
        Camera.ObjectToFollow = BCP;
        ZoomFixer.enabled = true;
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
        if (BossStage < 1)
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
            yield return new WaitForSeconds(15f);
            BossStage = 1;
            ProgressHandler.SetBossStage(1);
        }
        if (BossStage < 3)
        {
            MoveBattle(0, 1, 2, 60f);
            Arenas[0].SetActive(true);
        }        
        if (BossStage < 2)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine("AnvilAttack3");
            yield return new WaitForSeconds(7f);
            StartCoroutine("AnvilAttack3");
            yield return new WaitForSeconds(10f);
            BossStage = 2;
            ProgressHandler.SetBossStage(2);
        }
    }

    public void MoveBattle(int crabindex, int bossindex, int cameraindex, float zoom)
    {
        progress.Teleport(Waypoints[crabindex].transform.position);
        gameObject.transform.position = Waypoints[bossindex].transform.position;
        BCP.transform.position = Waypoints[cameraindex].transform.position;
        ZoomFixer.CamZoom = zoom;
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

    IEnumerator AnvilAttack3()
    {
        foreach (GameObject anvil in Anvils3)
        {
            yield return new WaitForSeconds(0.3f);
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
