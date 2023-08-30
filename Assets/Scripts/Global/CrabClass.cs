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
    public string winsStatName;
    public string name;
    public int maximumFarthestCheckpoint;

    public void setFarthestCheckpoint(int value)
    {
        farthestCheckpoint = value;
        ProgressHandler.SaveProgressData();
    }
}
