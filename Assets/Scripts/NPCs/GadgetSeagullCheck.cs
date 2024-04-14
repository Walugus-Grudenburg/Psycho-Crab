using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetSeagullCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoboCrabScript.mainInstance)
        {
            float distanceToRoboCrab = Vector3.Distance(gameObject.transform.position, RoboCrabScript.mainInstance.gameObject.transform.position);
            if (distanceToRoboCrab <= RoboCrabScript.nearestSeagullDistance)
            {
                RoboCrabScript.nearestSeagull = gameObject;
                RoboCrabScript.nearestSeagullDistance = distanceToRoboCrab;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Anti Seagull Beam") || other.CompareTag("Sulfuric Water")) Invoke("Delete", 0.1f);
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
