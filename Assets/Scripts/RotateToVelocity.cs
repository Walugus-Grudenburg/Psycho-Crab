using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour
{
    public Vector3 SpriteDirection;
    public bool KeepUpright;
    public float UprightSpeed;
    public float CollisionVelocityThreshold;
    public bool MovedByCrab;
    private Rigidbody2D rb;
    private Quaternion OriginalAngle;
    private HingeJoint2D crabHinge;
    bool justCollided = false;
    Controls controls;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        OriginalAngle = Quaternion.LookRotation(Vector3.forward, SpriteDirection) * Quaternion.AngleAxis(SpriteDirection.x * 90f, Vector3.forward);
        CrabLeg.StickStarted += CheckIfCrabGrabbedThis;
        controls = ProgressHandler.controls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    void FixedUpdate()
    {
        if (crabHinge)
        {
            float steeringAmount = controls.Crab.LeftLeg.ReadValue<float>() + controls.Crab.RightLeg.ReadValue<float>();
            Quaternion steeringAngle = rb.transform.rotation * Quaternion.AngleAxis(steeringAmount, Vector3.forward);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, steeringAngle, (60f + UprightSpeed) * -1 * Time.fixedDeltaTime);
        }

        if (!KeepUpright || justCollided)
        {
            Quaternion targetAngle = Quaternion.LookRotation(Vector3.forward, rb.velocity.normalized) * Quaternion.AngleAxis(SpriteDirection.x * 90f, Vector3.forward);
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, targetAngle, 360f * Time.fixedDeltaTime);
        }

        if (!justCollided)
        {
            rb.angularVelocity = 0f;
        }

        if (KeepUpright)
        {
            rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, OriginalAngle, UprightSpeed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > CollisionVelocityThreshold) 
        {
            justCollided = true;
            Invoke("EndCollision", 1f);
        }
    }

    void EndCollision()
    {
        justCollided = false;
    }

    void CheckIfCrabGrabbedThis(HingeJoint2D hinge)
    {
        if (hinge.connectedBody == rb)
        {
            crabHinge = hinge;
        }
    }
}
