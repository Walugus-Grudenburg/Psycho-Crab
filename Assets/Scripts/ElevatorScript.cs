using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public SpringJoint2D[] Ropes;
    public float Speed;
    private HingeJoint2D crabHinge;
    private Rigidbody2D rb;
    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = ProgressHandler.controls;
        CrabLeg.StickStarted += CheckIfCrabGrabbedThis;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (crabHinge)
        {
            float ropeChange = controls.Crab.LeftLeg.ReadValue<float>() + controls.Crab.RightLeg.ReadValue<float>();
            ChangeRopeSize(ropeChange);
        }
    }

    void CheckIfCrabGrabbedThis(HingeJoint2D hinge)
    {
        if (hinge.connectedBody == rb)
        {
            crabHinge = hinge;
        }
    }

    public void ChangeRopeSize(float amount)
    {
        foreach (SpringJoint2D rope in Ropes)
        {
            if (amount < 0)
            {
                rope.distance += amount * Time.fixedDeltaTime * Speed * ((rope.distance / 1.03f) - Mathf.Sqrt(Mathf.Pow(rope.distance, 1.98f)) + 1f);
            }
            else
            {
                rope.distance += amount * Time.fixedDeltaTime * Speed * 3;
            }
        }
    }
}
