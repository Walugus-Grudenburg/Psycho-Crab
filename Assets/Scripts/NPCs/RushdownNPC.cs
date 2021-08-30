using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushdownNPC : MonoBehaviour
{
    private Vector2 Direction;
    public float Speed;
    public GameObject Target;
    public Rigidbody2D RigidBody;
    public float SpeedFloor;
    public float SpeedCeling;
    // Start is called before the first frame update
    void Start()
    {
        if (!Target)
        {
            AreaParent ParentScript = gameObject.transform.parent.GetComponent<AreaParent>();
            if (ParentScript)
            {
                Target = ParentScript.Target;
                Speed = Random.Range(SpeedFloor, SpeedCeling);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Direction = (Target.transform.position - transform.position).normalized;
        RigidBody.MovePosition(RigidBody.position + (new Vector2(Direction.x, Direction.y) * Speed * Time.fixedDeltaTime));
        transform.rotation = Quaternion.LookRotation(Direction) * Quaternion.Euler(0,90,0);
    }
}
