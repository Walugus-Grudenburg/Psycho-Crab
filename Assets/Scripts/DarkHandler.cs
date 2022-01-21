using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class DarkHandler : MonoBehaviour
{
    public Material mat;
    public bool UseShapeMode;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DRC World 1"))
        {
            if (UseShapeMode)
            {
                SpriteShapeRenderer Shape = gameObject.GetComponent<SpriteShapeRenderer>();
                Shape.material = mat;
            } 
            else gameObject.GetComponent<SpriteRenderer>().material = mat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
