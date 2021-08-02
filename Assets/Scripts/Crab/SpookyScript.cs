using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Renderer.sprite = SpookyVersion;
    }
}
