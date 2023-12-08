using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveGoldenCrabPower : MonoBehaviour
{
    public GameObject crab;
    public CrabLeg[] legs;
    public GameObject satanVictoryZone;
    public AudioSource growSound;

    // Start is called before the first frame update
    void Start()
    {
        if (ProgressHandler.goldenCrabIsGiant) GivePower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GivePower();
        }
    }

    public void GivePower()
    {
        growSound.Play();
        ProgressHandler.DeTermination = true;
        crab.transform.localScale = new Vector2(3, 3);
        foreach (CrabLeg leg in legs)
        {
            leg.useDecaySystem = false;
            leg.StrengthStrength = 200;
        }
        satanVictoryZone.SetActive(true);
        this.enabled = false;
        ProgressHandler.SetGoldenCrabSize(true);
    }
}
