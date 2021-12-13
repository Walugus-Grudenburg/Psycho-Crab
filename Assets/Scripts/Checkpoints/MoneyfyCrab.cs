using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyfyCrab : MonoBehaviour
{
    public GameObject[] Moneys;
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
        foreach (GameObject Money in Moneys) 
        { 
            Money.SetActive(true); 
        }
        ProgressHandler.SetUnlockMoney(true);
    }
}
