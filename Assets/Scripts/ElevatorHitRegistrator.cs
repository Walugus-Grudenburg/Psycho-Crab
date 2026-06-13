using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHitRegistrator : MonoBehaviour
{
    public ElevatorScript Elevator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Elevator.ChangeRopeSize(collision.relativeVelocity.magnitude * (collision.otherRigidbody.mass + 50) / 2000);
    }
}
