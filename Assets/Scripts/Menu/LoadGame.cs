using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SatanScript.HasChaseStarted = false;
        SceneToLoad = ProgressHandler.SceneToLoad;
        IsContinuing = Continue;
        if (!MenuInstead) SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        else SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }
}
