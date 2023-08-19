using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIGASatanScript : MonoBehaviour
{
    public static int BossStage;
    public bool FightStarted;
    public bool IsMortal;
    public float FlightAmount;
    public int ForceStage;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    public CrabLeg[] Legs;
    public GameObject[] ObjectsToActivate;
    public Color currentRegularColor;
    public Color TiredColor1;
    public Color TiredColor2;
    public Color TiredColor3;
    public Color TiredColor4;
    public Color attackColor1;
    public Color attackColor2;
    public Color attackColor3;
    public GameObject music;
    public GameObject fakeoutmusic;
    public GameObject desparationMusic;
    public AudioSource EvilLaugh;
    public SpriteRenderer ownSprite;
    public Follow_Position Camera;
    public CameraZoomFixer ZoomFixer;
    // Start is called before the first frame update
    void Start()
    {
        ProgressHandler.LoadProgressData();
        BossStage = ProgressHandler.GIGABossStage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartFight()
    {
        FightStarted = true;
        foreach (CrabLeg leg in Legs)
        {
            leg.StrengthStrength = 2.6f;
        }
        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.SetActive(true);
        }
        Spooky.Active = true;
        Spooky.Recharge = true;
        Spooky.ChargeMulti = FlightAmount;
        Spooky.DisableCameraChanges = true;
        progress.IgnoreControls = true;
        ZoomFixer.enabled = true;
        ZoomFixer.CamZoom = 100f;
        SatanScript.HasChaseStarted = true;
        StartCoroutine("BossFight");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!FightStarted && collision.gameObject.CompareTag("Player"))
        {
            StartFight();
        }
    }
}
