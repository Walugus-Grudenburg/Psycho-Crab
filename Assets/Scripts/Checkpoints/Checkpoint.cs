using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 Checkpoint_Position;
    public bool DebugActivate;
    // Start is called before the first frame update
    void Start()
    {
        Checkpoint_Position = gameObject.transform.position;
    }
    private void Update()
    {
        if (DebugActivate)
        {
            ProgressHandler.Checkpoint_Position = Checkpoint_Position;
            ProgressHandler.SaveProgressData();
            DebugActivate = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            ProgressHandler.Checkpoint_Position = Checkpoint_Position;
            ProgressHandler.SaveProgressData();
        }
    }
}
