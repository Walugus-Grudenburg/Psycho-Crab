using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;

public class LoadGame : MonoBehaviour
{
    public bool Continue;
    string SceneToLoad;
    public static bool IsContinuing;
    public bool MenuInstead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        ProgressHandler.DeTermination = false;
        SatanScript.HasChaseStarted = false;
        Checkpoint.allCheckpoints.Clear();
        SceneToLoad = ProgressHandler.SceneToLoad;
        IsContinuing = Continue;
        Physics2D.gravity = new Vector2(0, -9.84f);
        if (!MenuInstead) SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        else
        {
            SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
            SteamUserStats.StoreStats();
        }
    }
}
