using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterTime : MonoBehaviour
{
    public float timemin;
    public float timemax;
    public GameObject toactivate;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Activate", Random.Range(timemin, timemax));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activate()
    {
        toactivate.SetActive(true);
    }
}
