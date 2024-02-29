using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public string levelID;
    public ActivateForTime challengeActiveWarning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoSelectLevel()
    {
        string levelSelected = ProgressHandler.SceneToLoad;
        if (levelSelected.Contains("Challenge"))
        {
            challengeActiveWarning.Activate();
            return;
        }
        else
        {
            // This solution will break if a level 10 or higher is ever made but that is unlikely to happen
            for (int i = 0; i < 10; i++)
            {
                levelSelected = levelSelected.Replace(i.ToString(), levelID);
            }
            ProgressHandler.SceneToLoad = levelSelected;
        }
    }
}
