using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDementiaCrab : MonoBehaviour
{
    public GameObject unlockText;
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
        if (collision.CompareTag("Player") && !ProgressHandler.DementiaCrabUnlocked)
        {
            unlockText.SetActive(true);
            ProgressHandler.SetUnlockDMC(true);
        }
    }
}
