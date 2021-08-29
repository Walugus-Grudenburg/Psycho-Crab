using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControlsDuringCutscene : MonoBehaviour
{
    public GameObject[] Legs;
    public GameObject Body;
    public float Time;
    public bool CallWhenAwake;
    // Start is called before the first frame update
    void Start()
    {
        if (CallWhenAwake)
        {
            DisableControls(Time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableControls(float time)
    {
        foreach (GameObject leg in Legs)
        {
            leg.GetComponent<CrabLeg>().enabled = false;
        }
        Body.GetComponent<SpookyJump>().enabled = false;
        Body.GetComponent<ProgressHandler>().enabled = false;
        StartCoroutine(ReenableControlsAfterTime(time));
    }

    IEnumerator ReenableControlsAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (GameObject leg in Legs)
        {
            leg.GetComponent<CrabLeg>().enabled = true;
        }
        Body.GetComponent<SpookyJump>().enabled = true;
        Body.GetComponent<ProgressHandler>().enabled = true;
    }
}
