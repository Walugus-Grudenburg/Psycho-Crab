using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : MonoBehaviour
{
    public SpringJoint2D[] Springs;
    public float TimeMin;
    public float TimeMax;
    public float PunchAmount;
    public float PunchForceMultiplier;
    public float PullbackTime;
    private Rigidbody2D rb;
    private bool midPunch;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetPunchTime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!midPunch)
        { 
            timeLeft -= Time.fixedDeltaTime;
            if (timeLeft <= 0f) Punch();
        }
    }

    public void Punch()
    {
        rb.WakeUp();
        foreach (SpringJoint2D spring in Springs)
        {
            spring.distance += PunchAmount;
            spring.frequency *= PunchForceMultiplier;
        }
        Invoke("PullBack", PullbackTime);
        midPunch = true;
    }

    public void ResetPunchTime()
    {
        timeLeft = Random.Range(TimeMin, TimeMax);
        midPunch = false;
    }

    public void PullBack()
    {
        foreach (SpringJoint2D spring in Springs)
        {
            spring.distance -= PunchAmount;
            spring.frequency /= PunchForceMultiplier;
        }
        ResetPunchTime();
    }
}
