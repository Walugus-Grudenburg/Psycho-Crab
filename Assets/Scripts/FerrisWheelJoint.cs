using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelJoint : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        if (ObjectToFollow)
        {
            gameObject.transform.position = ObjectToFollow.transform.position + ObjectToFollow.transform.rotation * Offset;
        }
        else Destroy(gameObject);
    }
}
