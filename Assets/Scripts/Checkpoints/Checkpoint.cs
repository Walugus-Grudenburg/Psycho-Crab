using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static List<Checkpoint> allCheckpoints = new List<Checkpoint>();
    public bool dementiaWasLastUsed;
    public GameObject text;
    public enum CheckpointMode {BC, DC, DRC, FC, GC, PHC, RC, RCC, RKC, SC, SPC, SDC, DMC, DCC, PC};
    public CheckpointMode Checkpoint_Mode;
    private Vector3 Checkpoint_Position;
    public bool DebugActivate;
    public int ID;
    public Remote_Checkpoint crabwarp;
    public ProgressHandler progress;
    // Start is called before the first frame update
    void Start()
    {
        allCheckpoints.Add(this);
        Checkpoint_Position = gameObject.transform.position;
    }
    private void Update()
    {
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
        switch (Checkpoint_Mode)
        {
            case CheckpointMode.BC:
                if (ID > ProgressHandler.BCFarthestCheckpoint)
                {
                    ProgressHandler.SetBCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.DC:
                if (ID > ProgressHandler.DCFarthestCheckpoint)
                {
                    ProgressHandler.SetDCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.DRC:
                if (ID > ProgressHandler.DRCFarthestCheckpoint)
                {
                    ProgressHandler.SetDRCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.FC:
                if (ID > ProgressHandler.FCFarthestCheckpoint)
                {
                    ProgressHandler.SetFCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.GC:
                if (ID > ProgressHandler.GCFarthestCheckpoint)
                {
                    ProgressHandler.SetGCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.PHC:
                if (ID > ProgressHandler.PHCFarthestCheckpoint)
                {
                    ProgressHandler.SetPHCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.RC:
                if (ID > ProgressHandler.RCFarthestCheckpoint)
                {
                    ProgressHandler.SetRCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.RKC:
                if (ID > ProgressHandler.RKCFarthestCheckpoint)
                {
                    ProgressHandler.SetRKCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.SC:
                if (ID > ProgressHandler.SCFarthestCheckpoint)
                {
                    ProgressHandler.SetSCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.SPC:
                if (ID > ProgressHandler.SPCFarthestCheckpoint)
                {
                    ProgressHandler.SetSPCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.SDC:
                if (ID > ProgressHandler.SDCFarthestCheckpoint)
                {
                    ProgressHandler.SetSDCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.DCC:
                if (ID > ProgressHandler.DCCFarthestCheckpoint)
                {
                    ProgressHandler.SetDCCFarthestCheckpoint(ID);
                }
                break;
            case CheckpointMode.PC:
                if (ID > ProgressHandler.PCFarthestCheckpoint)
                {
                    ProgressHandler.SetPCFarthestCheckpoint(ID);
                }
                break;
            default:
                break;
        }
    }

}



