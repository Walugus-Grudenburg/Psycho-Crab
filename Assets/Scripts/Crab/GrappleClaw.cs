using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleClaw : MonoBehaviour
{
    public bool IsLeftLeg;
    bool IsShootReady;
    bool IsShot;
    public bool isGadget;
    public CrabLeg LegScript;
    public HingeJoint2D ToggleJoint;
    Rigidbody2D Body;
    public float distance;
    public GameObject body;
    public PolygonCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        IsShootReady = true;
        Body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls controls = ProgressHandler.controls;
        if (IsShootReady)
        {
            if ((IsLeftLeg || isGadget) && controls.Crab.ClickLeft.triggered)
            {
                Shoot();
            }
            else if ((!IsLeftLeg || isGadget) && controls.Crab.ClickRight.triggered) 
            {
                Shoot();
            }
        }
        if (!IsShot && Vector3.Distance(transform.position, body.transform.position) >= distance)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }

    void Shoot()
    {
        Controls controls = ProgressHandler.controls;
        IsShootReady = false;
        IsShot = true;
        ToggleJoint.enabled = false;
        LegScript.StrengthStrength = 0f;
        if (IsLeftLeg && Mathf.Approximately(controls.Crab.Jump.ReadValue<float>(), 1)) Body.AddForce(gameObject.transform.right * -30000);
        else if (IsLeftLeg) Body.AddForce(gameObject.transform.right * -15000);
        else if (Mathf.Approximately(controls.Crab.Jump.ReadValue<float>(), 1) && !isGadget) Body.AddForce(gameObject.transform.right * 30000);
        else Body.AddForce(gameObject.transform.right * (15000 - 13500 * (isGadget ? 1:0)));
    }

    void Return()
    {
        IsShot = false;
        ToggleJoint.enabled = true;
        if (!isGadget) LegScript.StrengthStrength = 1f;
        else LegScript.StrengthStrength = 0.25f;
        StartCoroutine(CompleteReturn()); ;
    }

    IEnumerator CompleteReturn()
    {
        Controls controls = ProgressHandler.controls;
        yield return new WaitForSeconds(0.05f);
        while (((IsLeftLeg || isGadget) && Mathf.Approximately(controls.Crab.ClickLeft.ReadValue<float>(), 1)) || ((!IsLeftLeg || isGadget) && Mathf.Approximately(controls.Crab.ClickRight.ReadValue<float>(), 1))) 
        {
            yield return null;
        }
        LegScript.Unstick(LegScript.sticksound);
        IsShootReady = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsShot && !collision.gameObject.CompareTag("Player"))
        {
            Return();
            if (!collision.gameObject.CompareTag("Ungrabbable"))
            {
                LegScript.Stick(collision, LegScript.sticksound, 1f);
            }
        }
    }
}
