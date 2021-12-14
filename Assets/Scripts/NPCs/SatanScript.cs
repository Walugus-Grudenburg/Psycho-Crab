using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanScript : MonoBehaviour
{
    public static bool HasChaseStarted;
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

        SatanChaseScript.Speed = 8;
        Spooky.ChargeMulti = 3f;
        StartCoroutine(SpeedUpLoop());
    }

    IEnumerator SpeedUpLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            SatanChaseScript.Speed += 0.5f;
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
