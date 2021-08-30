using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Objects : MonoBehaviour
{
    public GameObject[] ObjectsToDestroy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObjects()
    {
        foreach (GameObject Object in ObjectsToDestroy)
        {
            Destroy(Object);
        }
    }
}
