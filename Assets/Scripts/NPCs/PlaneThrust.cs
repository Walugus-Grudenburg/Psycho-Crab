using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneThrust : MonoBehaviour
{
    public float Thrust;
    public float ThrustVariance;
    private float currentThrustOffset = 0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("RecalculateThrustOffset", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rb)
        {
            float thrustAfterVariance = Thrust + currentThrustOffset;
            rb.AddForce(transform.right * thrustAfterVariance * Time.fixedDeltaTime);
        }
    }

    void RecalculateThrustOffset()
    {
        currentThrustOffset = Random.Range(ThrustVariance * -1, ThrustVariance);
    }
}
