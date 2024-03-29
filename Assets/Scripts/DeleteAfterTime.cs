using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public bool disableInstead;
    public float timemin;
    public float timemax;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Delete", Random.Range(timemin, timemax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Delete()
    {
        if (!disableInstead)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
