using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpToSurfaceBelow : MonoBehaviour
{
    public bool warpAtStart;
    // Start is called before the first frame update
    void Start()
    {
        if (warpAtStart)
        {
            InvokeRepeating("WarpToSurface", 0f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void WarpToSurface()
    {
        Vector3 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2 (position.x, position.y + 0.1f), Vector2.down);
        if (hit.collider)
        {
            transform.position = hit.point;
        }    
    }
}
