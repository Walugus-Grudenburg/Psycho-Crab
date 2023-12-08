using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoRepair();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoRepair();
        }
    }

    private void DoRepair()
    {
        ProgressHandler.maininstance.GetComponent<FadeAway>().ResetFading();
        Destroy(gameObject);
    }
}
