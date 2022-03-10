using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalChild : MonoBehaviour
{
    public bool IsFacingLeft;
    public bool DontDestroyOnContact;
    public bool FixedSpeed;
    public float Speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (FixedSpeed) Speed = Random.Range(10f, 20f);
        if (IsFacingLeft) Speed *= -1;
    }

    // Update is called once per frames
    void Update()
    {
        rb.velocity = new Vector2 (0, rb.velocity.y) + Vector2.right * Speed;
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
        if (!collision.gameObject.CompareTag("Ungrabbable") && !collision.gameObject.CompareTag("Player") & !collision.gameObject.CompareTag("Cutscene NPC") && !DontDestroyOnContact)
        {
            Destroy(gameObject);
        }
    }
}
