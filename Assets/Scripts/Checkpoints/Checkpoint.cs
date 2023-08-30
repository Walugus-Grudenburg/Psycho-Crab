using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static List<Checkpoint> allCheckpoints = new List<Checkpoint>();
    public bool dementiaWasLastUsed;
    public bool isPortable;
    public GameObject text;
    public string checkpointModeName;
    private CrabClass checkpointMode;
    private Vector3 Checkpoint_Position;
    public bool DebugActivate;
    public int ID;
    public Remote_Checkpoint crabwarp;
    public ProgressHandler progress;
    // Start is called before the first frame update
    void Start()
    {
        SetCheckpointMode();
        allCheckpoints.Add(this);
        Checkpoint_Position = gameObject.transform.position;
    }
    private void Update()
    {
        if (isPortable)
        {
            Checkpoint_Position = gameObject.transform.position;
        }
        if (DebugActivate)
        {
            DoCheckpoint();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dementiaWasLastUsed)
        {
            if (SceneManager.GetActiveScene().name != "DMC World 1")
            {
                DoCheckpoint();

            }
            else
            {
                DoDementiaCheckpoint();
            }
        }    
    }

    void SetCheckpointMode()
    {
        foreach (CrabClass crab in ProgressHandler.allCrabClasses)
        {
            if (crab.name == checkpointModeName)
            {
                checkpointMode = crab;
                break;
            }
        }
    }

    private void DoDementiaCheckpoint()
    {
        foreach (Checkpoint cp in allCheckpoints)
        {
            cp.dementiaWasLastUsed = false;
        }
        Checkpoint checkpoint = allCheckpoints[Random.Range(0, allCheckpoints.Count)];
        checkpoint.DoCheckpoint();
        checkpoint.dementiaWasLastUsed = true;
        progress.Teleport(checkpoint.gameObject.transform.position);
        text.SetActive(true);
    }

    private void DoCheckpoint()
    {
        if (ProgressHandler.Checkpoint_Position != Checkpoint_Position)
        {
            ProgressHandler.Checkpoint_Position = Checkpoint_Position;
            ProgressHandler.SaveProgressData();
        }
        if (checkpointMode != null) if (ID > checkpointMode.farthestCheckpoint) checkpointMode.setFarthestCheckpoint(ID);
    }

}



