using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeWhenGrabbed : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CrabLeg.StickStarted += CheckIfCrabGrabbedThis;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckIfCrabGrabbedThis(HingeJoint2D hinge)
    {
        if (hinge.connectedBody == rb)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
