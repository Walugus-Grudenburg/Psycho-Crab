using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookifyCrab : MonoBehaviour
{
    public bool DebugActivate;
    public SpookyScript[] PartsToSpook;
    public SpookyJump Jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressHandler.Spookify || DebugActivate)
        {
            Spookify();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProgressHandler.Spookify = true;
        }
    }

    public void Spookify()
    {
        if (!ProgressHandler.JumpUnlocked) 
        { 
            ProgressHandler.SetUnlockJumping(true);
        }
        ProgressHandler.Spookify = false;
        foreach (SpookyScript part in PartsToSpook)
        {
            part.Spookify();
        }
        Jump.Active = true;
        Jump.Recharge = true;
        Destroy(gameObject.GetComponent<SpookifyCrab>());
    }
}
