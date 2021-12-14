using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSceneToLoad : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScene()
    {
        LoadGame.SceneToLoad = SceneToLoad;
    }
}
