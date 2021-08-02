using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public ResetHandler Handler;
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
            Handler.Checkpoint_Position = Checkpoint_Position;
            Handler.SaveResetData();
            DebugActivate = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Handler.Checkpoint_Position = Checkpoint_Position;
            Handler.SaveResetData();
        }
    }
}
