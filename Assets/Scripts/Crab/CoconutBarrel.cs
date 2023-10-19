using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutBarrel : SpookyJump
{
    public SpriteRenderer crab;
    public Sprite crabSprite;
    public Sprite barrelSprite;
    public Rigidbody2D rb;
    public GameObject trail;
    public AudioSource launchsound;
    int secondsSinceLastReversal;
    bool isBarrelActive;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for jump press when ready
        if (ProgressHandler.controls.Crab.Jump.triggered && Active & Charged > 0)
        {
            // Check whether to activate the barrel or launch from it
            if (isBarrelActive) LaunchFromBarrel();
            else ActivateBarrel();

        }
        else if (Recharge && Charged == 0)
        {
            Recharge = false;
            StartCoroutine(RechargeAfterTime(1 / ChargeMulti));
        }
    }

    void ActivateBarrel()
    {
        if (!DisableCameraChanges) Cam.orthographicSize -= 2f * Charged;
        Charged = 0;
        StopAllCoroutines();
        StartCoroutine(RechargeAfterTime(4.3f - ChargeMulti * 1.3f));
        rb.isKinematic = true;
        rb.velocity *= 0;
        isBarrelActive = true;
        rb.angularVelocity = -360f;
        crab.sprite = barrelSprite;
        InvokeRepeating("RandomlySwitchDirection", 1, 1);
    }

    void LaunchFromBarrel()
    {
        CancelInvoke();
        rb.isKinematic = false;
        rb.angularVelocity = 0f;
        Jump();
        isBarrelActive = false;
        launchsound.Play();
        crab.sprite = crabSprite;
        trail.SetActive(true);
    }

    public void RandomlySwitchDirection()
    {
        if (Random.Range(0, 10) < secondsSinceLastReversal)
        {
            rb.angularVelocity *= -1;
            secondsSinceLastReversal = 0;
            ChargedSound.Play();
        }
        secondsSinceLastReversal++;
    }

    public override void Jump()
    {
        // Add velocity to all of the parts
        foreach (Rigidbody2D part in JumpParts)
        {
            part.AddForce(gameObject.transform.up * Powermulti * 15000f * (0.9f + (Charged * (0.2f * Mathf.Clamp(((Charged - 5) * 0.15f), 1, 9999999)))));
        }
        // Change the camera back if it's supposed to be changed
        if (!DisableCameraChanges) Cam.orthographicSize -= 2f * Charged;
        // Reset everything to charge again
        Charged = 0;
        StopAllCoroutines();
        StartCoroutine(RechargeAfterTime(10f));
    }

    protected override IEnumerator RechargeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Charged += 1;
        if (!DisableCameraChanges) Cam.orthographicSize += 2f;
        ChargedSound.pitch = 0.75f + (Charged * 0.25f);
        ChargedSound.Play();
        if (Charged < 5 * ChargeMulti && Charged < MaximumCharges)
        {
            StartCoroutine(RechargeAfterTime((1 + Charged / ChargeMulti) / ChargeMulti));
        }
    }
}
