using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Position : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        gameObject.transform.position = ObjectToFollow.transform.position + Offset; // Sets the attached object's position to the selected object's
    }
}
