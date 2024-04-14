using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDownwardsWhenSpawned : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.velocity -= new Vector2(0f, Random.Range(minspeed, maxspeed));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
