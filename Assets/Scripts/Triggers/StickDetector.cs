using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickDetector : MonoBehaviour
{
    public bool Detected;
    public MonoBehaviour[] ScriptsToWakeUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Detected){
            foreach (MonoBehaviour Script in ScriptsToWakeUp)
            {
                if (Script) { 
                    Script.enabled = true;
                }
            }
            Destroy(gameObject.GetComponent<StickDetector>());
        }
    }
}
