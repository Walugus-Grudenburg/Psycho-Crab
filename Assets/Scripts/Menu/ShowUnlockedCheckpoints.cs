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
            case Checkpoint.CheckpointMode.RCC:
                for (int i = 0; i < ProgressHandler.RCCFarthestCheckpoint + 1; i++)
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
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}
