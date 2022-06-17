using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartScript : MonoBehaviour
{

    Vector3 ReturnPosition;
    Quaternion ReturnRotation;
    public bool StayEnabled;
    public bool UsePos;
    public bool UseRot;
    public bool ReturnOnHitUngrabbable;
    public bool ReturnWhenWet;
    public float ReturnAfterTime;
    public CrabLeg leggrabbed;
    new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ReturnPosition = gameObject.transform.position;
        ReturnRotation = gameObject.transform.rotation;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping())
        {
            Return();
        }
    }

    public void Return()
    {
        if (leggrabbed) leggrabbed.Unstick(null);
        if (UsePos) gameObject.transform.position = ReturnPosition;
        if (UseRot) gameObject.transform.rotation = ReturnRotation;
        if (!StayEnabled) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ReturnWhenWet && collision.CompareTag("Water"))
        {
            Return();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ReturnOnHitUngrabbable && !collision.gameObject.CompareTag("Ungrabbable"))
        {
            Return();
        }
    }
}
