using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public enum CheckpointMode {BC, DC, DRC, FC, GC, PHC, RC, RCC, RKC, SC, SPC};
    public CheckpointMode Checkpoint_Mode;
    private Vector3 Checkpoint_Position;
    public bool DebugActivate;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        Checkpoint_Position = gameObject.transform.position;
    }
    private void Update()
    {
        if (DebugActivate)
        {

            if (ProgressHandler.Checkpoint_Position != Checkpoint_Position)
            {
                ProgressHandler.Checkpoint_Position = Checkpoint_Position;
                ProgressHandler.SaveProgressData();
            }
            DebugActivate = false;
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
                case CheckpointMode.RCC:
                    if (ID > ProgressHandler.RCCFarthestCheckpoint)
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
                default:
                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
                case CheckpointMode.RCC:
                    if (ID > ProgressHandler.RCCFarthestCheckpoint)
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
                default:
                    break;
            }
        }
    }

}



