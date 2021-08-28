using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneNPC : MonoBehaviour
{
    public Vector2 Direction;
    public Vector3 Rotation;
    public float Speed;
    public Rigidbody2D RigidBody;
    public bool IsEvil;
    // Start is called before the first frame update
    void Start()
    {
        if (IsEvil)
        {
            Invoke("DisableThis", 1f);
        }
    }

    void DisableThis()
    {
        enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RigidBody.MovePosition(RigidBody.position + (new Vector2(Direction.x, Direction.y) * Speed * Time.fixedDeltaTime));
        gameObject.transform.rotation = Quaternion.Euler(Rotation);
    }
}
