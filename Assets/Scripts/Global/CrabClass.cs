using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CrabClass
{
    public int legacyFarthestCheckpoint;
    public int farthestCheckpoint;
    public int numberOfWins;
    public int numberOfLevel2Wins;
    public string winsStatName;
    public string name;
    public int maximumFarthestCheckpoint;
    public int farthestCheckpointLevel2;
    public int maximumFarthestCheckpointLevel2;

    public void setFarthestCheckpoint(int value)
    {
        farthestCheckpoint = value;
        ProgressHandler.SaveProgressData();
    }

    public void setFarthestCheckpointLevel2(int value)
    {
        farthestCheckpointLevel2 = value;
        ProgressHandler.SaveProgressData();
    }
}
