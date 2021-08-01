using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasolUp : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = Random.Range(7f, 14f);
    }

    // Update is called once per frames
    void Update()
    {
        rb.velocity = new Vector2 (rb.velocity.x, 0) + Vector2.up * Speed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Area Parent"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
