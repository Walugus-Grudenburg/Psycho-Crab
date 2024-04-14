using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 offset = collision.ClosestPoint(transform.position);
            StickToObject(collision.gameObject, offset);
        }
    }

    public void StickToObject(GameObject objectToStickTo, Vector2 offset)
    {
        if (rb)
        {
            Rigidbody2D otherRB = objectToStickTo.GetComponent<Rigidbody2D>();
            if (otherRB)
            {
                FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
                joint.enableCollision = true;
                joint.autoConfigureConnectedAnchor = true;
                joint.connectedBody = otherRB;
            }
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
        Destroy(this);
    }

}
