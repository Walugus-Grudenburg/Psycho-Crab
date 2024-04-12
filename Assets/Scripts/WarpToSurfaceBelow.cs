using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpToSurfaceBelow : MonoBehaviour
{
    public float offset;
    public bool warpAtStart;
    public float updateRate;
    // Start is called before the first frame update
    void Start()
    {
        if (warpAtStart)
        {
            InvokeRepeating("WarpToSurface", 0f, updateRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void WarpToSurface()
    {
        Vector3 position = transform.position;
        ContactFilter2D ignoretriggers = new ContactFilter2D();
        ignoretriggers.useTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2 (position.x, position.y + offset), Vector2.down, 9999999f, ~4);
        if (hit.collider)
        {
            transform.position = hit.point;
        }    
    }
}
