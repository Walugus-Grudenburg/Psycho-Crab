using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisRandomly : MonoBehaviour
{
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator ToggleLoop()
    {
        yield return new WaitForSeconds(0.05f);
        if (Random.Range(0,100) == 0)
        {
            renderer.enabled = !renderer.enabled;
        }
        StartCoroutine(ToggleLoop());
    }
}
