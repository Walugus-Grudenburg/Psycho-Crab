using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalChild : MonoBehaviour
{
    public float Speed;
    public float SpeedMulti;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = Random.Range(7f * SpeedMulti, 14f * SpeedMulti);
    }

    // Update is called once per frames
    void Update()
    {
        if (SpeedMulti != 0) {
            rb.velocity = new Vector2(rb.velocity.x, 0) + Vector2.up * Speed;
        }
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
