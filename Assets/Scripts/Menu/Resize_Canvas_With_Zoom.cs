using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize_Canvas_With_Zoom : MonoBehaviour
{
    public Camera ZoomCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.one * 0.1085271f * ZoomCamera.orthographicSize / 14;
    }
}
