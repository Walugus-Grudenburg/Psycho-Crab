using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public bool Continue;
    public string SceneToLoad;
    public static bool IsContinuing;
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
        IsContinuing = Continue;
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
}
