using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote_Checkpoint : MonoBehaviour
{
    public Checkpoint Destination;
    public ResetHandler CrabToWarp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CrabToWarp.Checkpoint_Position = Destination.gameObject.transform.position;
            CrabToWarp.SaveResetData();
            CrabToWarp.Reset();
        }
    }
}
