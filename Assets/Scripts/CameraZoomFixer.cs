using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomFixer : MonoBehaviour
{
    public float CamZoom;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        cam.orthographicSize = CamZoom;
    }
}
