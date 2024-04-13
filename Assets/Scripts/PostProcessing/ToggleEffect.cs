using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ToggleEffect : MonoBehaviour
{
    public PostProcessVolume effectToToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePostProcessEffect()
    {
        effectToToggle.enabled = !effectToToggle.enabled;
    }
}
