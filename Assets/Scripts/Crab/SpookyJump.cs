using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyJump : MonoBehaviour
{
    public bool Active;
    public bool Recharge;
    public Camera Cam;
    public int Charged;
    public Rigidbody2D[] JumpParts;
    public AudioSource ChargedSound;
    public float ChargeMulti;
    public float Powermulti;
    public bool DisableCameraChanges;
    public int MaximumCharges = 99999999;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Jump if it's pressed and ready
        if (ProgressHandler.controls.Crab.Jump.triggered && Active & Charged > 0)
        {
            Jump();
        }
        // Otherwise recharge if it needs it
        else if (Recharge && Charged == 0)
        {
            Recharge = false;
            StartCoroutine(RechargeAfterTime(1 / ChargeMulti));
        }

    }

    public virtual void Jump()
    {
        // Add velocity to all of the parts
        foreach (Rigidbody2D part in JumpParts)
        {
            part.AddForce(gameObject.transform.up * Powermulti * 5000f * (0.9f + (Charged * (0.2f * Mathf.Clamp(((Charged - 5) * 0.15f), 1, 9999999)))));
        }
        // Change the camera back if it's supposed to be changed
        if (!DisableCameraChanges) Cam.orthographicSize -= 2f * Charged;
        // Reset everything to charge again
        Charged = 0;
        StopAllCoroutines();
        StartCoroutine(RechargeAfterTime(4.3f - ChargeMulti * 1.3f));
    }

    public void ShutDown()
    {
        Jump();
        StopAllCoroutines();
        Recharge = false;
        Active = false;
    }

    protected virtual IEnumerator RechargeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Charged += 1;
        if (!DisableCameraChanges) Cam.orthographicSize += 2f;
        ChargedSound.pitch = 2f + (Charged * 0.25f);
        ChargedSound.Play();
        if (Charged < 5 * ChargeMulti && Charged < MaximumCharges)
        {
            StartCoroutine(RechargeAfterTime((1 + Charged / ChargeMulti) / ChargeMulti));
        }
    }
}
