using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCrabClawReturn : MonoBehaviour
{
    public GameObject body;
    public float distance;
    public PolygonCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, body.transform.position) >= distance)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }
}
