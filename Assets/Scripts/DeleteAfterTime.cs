using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public float timemin;
    public float timemax;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", Random.Range(timemin, timemax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
