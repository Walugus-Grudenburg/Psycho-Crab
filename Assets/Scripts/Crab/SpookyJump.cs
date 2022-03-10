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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressHandler.controls.Crab.Jump.triggered && Active & Charged > 0)
        {
            Jump();
        }
        else if (Recharge && Charged == 0)
        {
            Recharge = false;
            StartCoroutine(RechargeAfterTime(1 / ChargeMulti));
        }

    }

    public void Jump()
    {
        foreach (Rigidbody2D part in JumpParts)
        {
            part.AddForce(gameObject.transform.up * Powermulti * 5000f * (0.9f + (Charged * (0.2f * Mathf.Clamp(((Charged - 5) * 0.15f), 1, 9999999)))));
        }
        Cam.orthographicSize -= 2f * Charged;
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

    IEnumerator RechargeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Charged += 1;
        Cam.orthographicSize += 2f;
        ChargedSound.pitch = 2f + (Charged * 0.25f);
        ChargedSound.Play();
        if (Charged < 5 * ChargeMulti)
        {
            StartCoroutine(RechargeAfterTime((1 + Charged / ChargeMulti) / ChargeMulti));
        }
    }
}
