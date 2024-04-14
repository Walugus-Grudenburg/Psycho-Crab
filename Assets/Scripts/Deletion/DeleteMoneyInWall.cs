using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMoneyInWall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vertical Terrain") || collision.CompareTag("Terrain"))
        {
            if (!collision.GetComponent<Rigidbody2D>())
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Vertical Terrain") || collision.CompareTag("Terrain"))
        {
            if (!collision.GetComponent<Rigidbody2D>())
            {
                Destroy(gameObject);
            }
        }
    }
}
