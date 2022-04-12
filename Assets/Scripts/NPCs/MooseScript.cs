using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseScript : MonoBehaviour
{
    private Vector2 Direction;
    public ProgressHandler progress;
    public float Speed;
    public GameObject Target;
    public AudioSource source;
    public Rigidbody2D RigidBody;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Direction = (Target.transform.position - transform.position).normalized;
        RigidBody.AddForce((new Vector2(Direction.x, 0) * Speed * Time.fixedDeltaTime * 10000));
        transform.rotation = Quaternion.LookRotation(Direction) * Quaternion.Euler(0, 90, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            progress.Reset();
            source.Play();
        }
    }
}
