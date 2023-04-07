using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanScript : MonoBehaviour
{
    public bool StartChaseSoon;
    public bool DebugStartChase;
    public static bool HasChaseStarted;
    public float FlightAmount;
    public float SpeedUpAmount = 0.5f;
    public float ChaseStartSpeed = 8;
    public Camera cam;
    public HingeJoint2D[] CrabLegs;
    public GameObject[] ObjectsToDestroy;
    public GameObject[] ObjectsToActivate;
    public RushdownNPC SatanChaseScript;
    public SpookyJump Spooky;
    public ProgressHandler progress;
    // Start is called before the first frame update
    void Start()
    {
        HasChaseStarted = false;
        if (StartChaseSoon) Invoke("StartChaseSequence", 0.25f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (DebugStartChase) 
        {
            StartChaseSequence();
            DebugStartChase = false;
        }
    }
    
    public void StartChaseSequence()
    {
        HasChaseStarted = true;
        progress.IgnoreControls = true;
        foreach (GameObject obj in ObjectsToDestroy)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.SetActive(true);
        }

        foreach (HingeJoint2D hinge in CrabLegs)
        {
            hinge.breakForce = Mathf.Infinity;
        }

        SatanChaseScript.Speed = ChaseStartSpeed;
        Spooky.Active = true;
        Spooky.Recharge = true;
        Spooky.ChargeMulti = FlightAmount;
        Spooky.DisableCameraChanges = true;
        cam.orthographicSize += 20;
        StartCoroutine(SpeedUpLoop());
    }

    IEnumerator SpeedUpLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(18f);
            SatanChaseScript.Speed += SpeedUpAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ProgressHandler.MoneyUnlocked && !HasChaseStarted && collision.gameObject.CompareTag("Player"))
        {
            StartChaseSequence();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            progress.Reset();
        }
    }
}
