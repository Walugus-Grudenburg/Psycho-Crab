using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggleScript : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        bool MusicCache = MusicScript.MusicEnabled;
        toggle.isOn = MusicScript.MusicEnabled;
        MusicScript.MusicEnabled = MusicCache;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        MusicScript.MusicEnabled = !MusicScript.MusicEnabled;
    }
}
