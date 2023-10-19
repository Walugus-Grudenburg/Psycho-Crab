using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySatanWhenCoconutFalls : MonoBehaviour
{
    public GameObject satan;
    public GameObject victory;
    public AudioSource deathScreech;
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
        if (collision.CompareTag("Cutscene NPC"))
        {
            CutsceneNPC NPC = collision.GetComponent<CutsceneNPC>();
            if (NPC)
            {
                if (!NPC.IsEvil)
                {
                    satan.SetActive(false);
                    victory.SetActive(true);
                    deathScreech.Play();
                    ObjectRotator rotator = collision.GetComponent<ObjectRotator>();
                    if (rotator) rotator.enabled = false;
                }
            }
        }
    }
}
