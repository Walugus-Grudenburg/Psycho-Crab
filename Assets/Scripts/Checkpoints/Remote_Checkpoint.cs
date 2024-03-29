using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote_Checkpoint : MonoBehaviour
{
    public Checkpoint Destination;
    public ProgressHandler CrabToWarp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Warp()
    {
        if (Destination)
        {
            ProgressHandler.Checkpoint_Position = Destination.gameObject.transform.position;
            ProgressHandler.SaveProgressData();
            CrabToWarp.Reset(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Warp();
        }
    }
}
