using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSeagullBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoboCrabScript.nearestSeagull) 
        {
            Vector3 Direction = (RoboCrabScript.nearestSeagull.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(Direction) * Quaternion.Euler(0, 90, 90);
        }
    }
}
