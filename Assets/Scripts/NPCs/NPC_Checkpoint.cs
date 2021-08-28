using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Checkpoint : MonoBehaviour
{
    public Vector2 Direction;
    public Vector3 Rotation;
    public float Speed;
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
        if (collision.CompareTag("Cutscene NPC")) {
        CutsceneNPC NPC = collision.GetComponent<CutsceneNPC>();
            if (!NPC.IsEvil)
            {
                NPC.Direction = Direction;
                NPC.Rotation = Rotation;
                NPC.Speed = Speed;
            }
        }
    }
}

