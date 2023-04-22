using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSatanScript : MonoBehaviour
{
    public static int BossStage;
    public bool FightStarted;
    public bool IsMortal;
    bool ParasolsDone;
    public float FlightAmount;
    public int ForceStage;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    public CrabLeg[] Legs;
    public Color TiredColor1;
    public Color TiredColor2;
    public Color TiredColor3;
    public Color TiredColor4;
    public VictoryManager Victory;
    public GameObject[] ObjectsToActivate;
    public GameObject[] Wings;
    public GameObject[] ObjectsToDestroy;
    public GameObject[] Anvils;
    public GameObject[] Anvils2;
    public GameObject[] Anvils3;
    public GameObject[] Seagulls;
    public GameObject[] Seagulls2;
    public GameObject[] Parasols;
    public GameObject[] Waypoints;
    public GameObject[] Arenas;
    public GameObject[] Swans;
    public GameObject[] Swans2;
    public GameObject[] Coral;
    public GameObject[] Pianos;
    public GameObject[] Pianos2;
    public GameObject[] FallingBodies;
    public GameObject[] FallingBodiesWithSeagulls;
    public GameObject Swing1;
    public GameObject BCP;
    public GameObject DeathLava;
    public GameObject chicken;
    public GameObject music;
    public GameObject fakeoutmusic;
    public GameObject desparationMusic;
    public AudioSource EvilLaugh;
    public AreaParent FallingAttack;
    public SpriteRenderer sprite;
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
        Spooky.DisableCameraChanges = true;
        progress.IgnoreControls = true;
        ZoomFixer.enabled = true;
        if (BossStage < 6)
        {
            ProgressHandler.DeTermination = false;
            Camera.ObjectToFollow = BCP;
        }
        else
        {
            ZoomFixer.CamZoom = 100f;
        }
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
            StartCoroutine("ParasolAttack", 30f);
            while (!ParasolsDone)
            {
                yield return new WaitForSeconds(1f);
            }
            ParasolsDone = false;
            BossStage = 3;
            ProgressHandler.SetBossStage(3);
        }
        if (BossStage < 4)
        {
            Spooky.ShutDown();
            foreach (GameObject wing in Wings)
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
            yield return new WaitForSeconds(46f);
            foreach (GameObject swan in Swans2)
            {
                swan.SetActive(false);
            }
            Arenas[1].SetActive(false);
            MoveBattle(6, 7, 8, 60f);
            Arenas[2].SetActive(true);
            foreach (GameObject coral in Coral)
            {
                coral.SetActive(true);
            }
            yield return new WaitForSeconds(45f);
            foreach (GameObject coral in Coral)
            {
                coral.SetActive(false);
            }
            sprite.color = TiredColor1;
            yield return new WaitForSeconds(0.5f);
            Spooky.Active = true;
            Spooky.Recharge = true;
            Spooky.ChargeMulti = FlightAmount;
            Spooky.DisableCameraChanges = true;
            foreach (GameObject wing in Wings)
            {
                wing.SetActive(true);
            }
            MoveBattle(0, 1, 2, 60f);
            Arenas[0].SetActive(true);
            yield return new WaitForSeconds(3.5f);
            StartCoroutine("ParasolAttack", 2f);
            while (!ParasolsDone)
            {
                yield return new WaitForSeconds(1f);
            }
            BossStage = 4;
            ProgressHandler.SetBossStage(4);
            yield return new WaitForSeconds(0.5f);
            progress.Reset(true);
        }
        sprite.color = TiredColor1;
        if (BossStage < 5)
        {
            StartCoroutine("SeagullAttack2");
            yield return new WaitForSeconds(32.5f);
            foreach (GameObject piano in Pianos)
            {
                piano.SetActive(true);
            }
            yield return new WaitForSeconds(9.5f);
            Spooky.ShutDown();
            foreach (GameObject wing in Wings)
            {
                wing.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
            MoveBattle(9, 10, 11, 80f);
            Arenas[3].SetActive(true);
            yield return new WaitForSeconds(8f);
            Arenas[3].SetActive(false);
            yield return new WaitForSeconds(0.5f);
            sprite.color = TiredColor2;
            BossStage = 5;
            ProgressHandler.SetBossStage(5);
        }
        if (BossStage < 6)
        {
            sprite.color = TiredColor2;
            Destroy(music);
            Destroy(fakeoutmusic);
            desparationMusic.SetActive(true);
            Spooky.ShutDown();
            foreach (GameObject wing in Wings)
            {
                wing.SetActive(false);
            }
            yield return new WaitForSeconds(1f);
            MoveBattle(12, 13, 14, 60f);
            Arenas[4].SetActive(true);
            yield return new WaitForSeconds(5f);
            Spooky.Active = true;
            Spooky.Recharge = true;
            Spooky.ChargeMulti = 2.66f;
            Spooky.DisableCameraChanges = true;
            foreach (GameObject wing in Wings)
            {
                wing.SetActive(true);
                wing.transform.localScale *= 0.75f;
            }
            yield return new WaitForSeconds(26f);
            StartCoroutine("Pianos2Attack");
            yield return new WaitForSeconds(22f);
            yield return new WaitForSeconds(12f);
            sprite.color = TiredColor3;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("DestroyFallingAttackChildren");
            FallingAttack.ObjectToSpawn = FallingBodies;
            yield return new WaitForSeconds(3f);
            Spooky.ChargeMulti = 4f;
            foreach (GameObject wing in Wings)
            {
                wing.transform.localScale *= 1.50f;
            }
            yield return new WaitForSeconds(18.5f);
            StartCoroutine("Pianos2Attack");
            yield return new WaitForSeconds(22.5f);
            StartCoroutine("Pianos2Attack");
            yield return new WaitForSeconds(22.5f);
            sprite.color = TiredColor4;
            FallingAttack.ObjectToSpawn = FallingBodiesWithSeagulls;
            while (SeagullCounter.Count < 24)
            {
                yield return new WaitForSeconds(1f);
            }
            sprite.color = Color.white;
            desparationMusic.SetActive(false);
            yield return new WaitForSeconds(2f);
            EvilLaugh.Play();
            yield return new WaitForSeconds(2f);
            BossStage = 6;
            ProgressHandler.SetBossStage(6);
            Spooky.ShutDown();
            foreach (GameObject wing in Wings)
            {
                wing.SetActive(false);
            }
        }
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Waypoints[15].transform.position = new Vector3(Waypoints[15].transform.position.x, Waypoints[15].transform.position.y + 50f, Waypoints[15].transform.position.z);
        MoveBattle(15, 16, 17, 100f);
        IsMortal = true;
        EvilLaugh.Play();
        sprite.color = Color.white;
        DeathLava.SetActive(true);
        foreach (Object obj in ObjectsToActivate)
        {
            Destroy(obj);
        }
        gameObject.GetComponent<RushdownNPC>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        Rigidbody2D RB = gameObject.GetComponent<Rigidbody2D>();
        RB.isKinematic = false;
    }

    public void MoveBattle(int crabindex, int bossindex, int cameraindex, float zoom)
    {
        progress.Teleport(Waypoints[crabindex].transform.position);
        gameObject.transform.position = Waypoints[bossindex].transform.position;
        BCP.transform.position = Waypoints[cameraindex].transform.position;
        BCP.transform.parent = Waypoints[cameraindex].transform.parent;
        ZoomFixer.CamZoom = zoom;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death Lava"))
        {
            Victory.Win(5f);
            Destroy(sprite);
            chicken.SetActive(true);
        }
    }

    IEnumerator DestroyFallingAttackChildren()
    {
        foreach (Transform child in FallingAttack.transform)
        {
            Destroy(child.gameObject);
            yield return new WaitForSeconds (1f);
        }
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

    IEnumerator SeagullAttack2()
    {
        foreach (GameObject seagull in Seagulls2)
        {
            yield return new WaitForSeconds(0.5f);
            seagull.SetActive(true);
        }
    }

    IEnumerator Pianos2Attack()
    {
        foreach (GameObject piano in Pianos2)
        {
            piano.SetActive(true);
            yield return new WaitForSeconds(11f);
        }
    }

    IEnumerator ParasolAttack(float repeattimes)
    {
        Parasols[0].SetActive(true);
        yield return new WaitForSeconds(4f);
        Parasols[1].SetActive(true);
        Parasols[2].SetActive(true);
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < repeattimes; i++)
        {
            Parasols[Random.Range(3, 6)].SetActive(true);
            yield return new WaitForSeconds(2.6f - i * 0.085f);
        }
        ParasolsDone = true;
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
