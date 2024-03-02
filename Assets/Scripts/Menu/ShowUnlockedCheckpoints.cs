using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnlockedCheckpoints : MonoBehaviour
{
    public string checkpointModeName;
    private CrabClass checkpointMode;
    public bool level2;
    public GameObject[] buttons;

    void Start()
    {

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

    void OnEnable()
    {
        SetCheckpointMode();
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        if (!level2)
        {
            for (int i = 0; i < checkpointMode.farthestCheckpoint + 1; i++)
            {
                buttons[i].SetActive(true);
            }
        }
        else 
        {
            for (int i = 0; i < checkpointMode.farthestCheckpointLevel2; i++)
            {
                buttons[i].SetActive(true);
            }
        }
    }

    void Update()
    {

    }
}
