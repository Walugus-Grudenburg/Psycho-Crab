using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnlockedCheckpoints : MonoBehaviour
{
    public Checkpoint.CheckpointMode mode;
    public GameObject[] buttons;

    void Start()
    {
        
    }

    void OnEnable()
    {
        switch (mode)
        {
            case Checkpoint.CheckpointMode.BC:
                for (int i = 0; i < ProgressHandler.BCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.DC:
                for (int i = 0; i < ProgressHandler.DCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.DRC:
                for (int i = 0; i < ProgressHandler.DRCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.FC:
                for (int i = 0; i < ProgressHandler.FCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.GC:
                for (int i = 0; i < ProgressHandler.GCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.PHC:
                for (int i = 0; i < ProgressHandler.PHCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.RC:
                for (int i = 0; i < ProgressHandler.RCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.RKC:
                for (int i = 0; i < ProgressHandler.RKCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.SC:
                for (int i = 0; i < ProgressHandler.SCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.SPC:
                for (int i = 0; i < ProgressHandler.SPCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.SDC:
                for (int i = 0; i < ProgressHandler.SDCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.DCC:
                for (int i = 0; i < ProgressHandler.DCCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.PC:
                for (int i = 0; i < ProgressHandler.PCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.GLC:
                for (int i = 0; i < ProgressHandler.GLCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.PCC:
                for (int i = 0; i < ProgressHandler.PCCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            case Checkpoint.CheckpointMode.RBC:
                for (int i = 0; i < ProgressHandler.RBCFarthestCheckpoint + 1; i++)
                {
                    buttons[i].SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}
