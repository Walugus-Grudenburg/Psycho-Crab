using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisRandomly : MonoBehaviour
{
    SpriteRenderer rendererer;
    // Start is called before the first frame update
    void Start()
    {
        rendererer = GetComponent<SpriteRenderer>();
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
            rendererer.enabled = !rendererer.enabled;
        }
        StartCoroutine(ToggleLoop());
    }
}
