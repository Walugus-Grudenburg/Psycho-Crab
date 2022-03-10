using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSatanScript : MonoBehaviour
{
    public static int BossStage;
    public bool FightStarted;
    bool ParasolsDone;
    public float FlightAmount;
    public int ForceStage;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    public CrabLeg[] Legs;
    public GameObject[] ObjectsToActivate;
    public GameObject[] Wings;
    public GameObject[] ObjectsToDestroy;
    public GameObject[] Anvils;
    public GameObject[] Anvils2;
    public GameObject[] Anvils3;
    public GameObject[] Seagulls;
    public GameObject[] Parasols;
    public GameObject[] Waypoints;
    public GameObject[] Arenas;
    public GameObject[] Swans;
    public GameObject[] Swans2;
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
        if (ForceStage > 0)
        {
            BossStage = ForceStage;
            ProgressHandler.SetBossStage(ForceStage);
            ForceStage = 0;
        }
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
        if (BossStage < 3)
        {
            StartCoroutine("ParasolAttack");
            while (!ParasolsDone)
            {
                yield return new WaitForSeconds(1f);
            }
            BossStage = 3;
            ProgressHandler.SetBossStage(3);
        }
        if (BossStage < 4)
        {
            Spooky.ShutDown();
            foreach  (GameObject wing in Wings)
            {
                wing.SetActive(false);
            }
            MoveBattle(3, 4, 5, 60f);
            Arenas[1].SetActive(true);
            StartCoroutine("ReleaseSwans");
            yield return new WaitForSeconds(30f);
            foreach (GameObject swan in Swans)
            {
                swan.SetActive(false);
            }
            yield return new WaitForSeconds(2f);
            StartCoroutine("ReleaseSwans2");
            yield return new WaitForSeconds(20f);
            foreach (GameObject swan in Swans2)
            {
                swan.SetActive(false);
            }
        }
    }

    public void MoveBattle(int crabindex, int bossindex, int cameraindex, float zoom)
    {
        progress.Teleport(Waypoints[crabindex].transform.position);
        gameObject.transform.position = Waypoints[bossindex].transform.position;
        BCP.transform.position = Waypoints[cameraindex].transform.position;
        BCP.transform.parent = Waypoints[cameraindex].transform.parent;
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

    IEnumerator ParasolAttack()
    {
        Parasols[0].SetActive(true);
        yield return new WaitForSeconds(4f);
        Parasols[1].SetActive(true);
        Parasols[2].SetActive(true);
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < 30; i++)
        {
            Parasols[Random.Range(3, 6)].SetActive(true);
            yield return new WaitForSeconds(2.6f - i * 0.085f);
        }
    }

    IEnumerator ReleaseSwans()
    {
        foreach (GameObject swan in Swans)
        {
            yield return new WaitForSeconds(0.1f);
            swan.SetActive(true);
        }
    }

    IEnumerator ReleaseSwans2()
    {
        foreach (GameObject swan in Swans2)
        {
            yield return new WaitForSeconds(0.1f);
            swan.SetActive(true);
        }
    }
}
