using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCameraPosition : MonoBehaviour
{
    public float sizeX;
    public float sizeY;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (!cam) cam = GetComponent<Camera>();
        Rect viewportrect = cam.rect;
        viewportrect.x = Random.Range(0.000f, sizeX);
        viewportrect.y = Random.Range(0.000f, sizeY);
        cam.rect = viewportrect;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
