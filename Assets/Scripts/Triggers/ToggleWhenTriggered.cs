using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWhenTriggered : MonoBehaviour
{
    public GameObject[] Objects;
    bool State;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        foreach (GameObject obj in Objects)
        {
            State = !State;
            obj.SetActive(State);
        }
    }
}
