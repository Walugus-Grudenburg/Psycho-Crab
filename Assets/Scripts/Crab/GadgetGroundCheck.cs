using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetGroundCheck : MonoBehaviour
{
    public static bool anyIsGrounded;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!anyIsGrounded & isGrounded) anyIsGrounded = true;
    }

    void LateUpdate()
    {
        isGrounded = false;
        anyIsGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
