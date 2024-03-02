using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpookyScript : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Sprite SpookyVersion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spookify()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "World 1" || name.Contains("GLC World") || name == "World 2") Renderer.sprite = SpookyVersion;
    }
}
