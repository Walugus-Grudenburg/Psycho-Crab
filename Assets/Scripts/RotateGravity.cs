using UnityEngine;

public class RotateGravity : MonoBehaviour
{
    private Vector2 gravityDirection;
    public float gravityScale;

    void Start()
    {
        gravityDirection = new Vector2(0f,-1);
    }

    void FixedUpdate()
    {
        Vector2 currentGravity = Quaternion.Euler(0f, 0f, -transform.eulerAngles.z) * gravityDirection;
        currentGravity.x = -currentGravity.x;
        Physics2D.gravity = currentGravity * Mathf.Abs(gravityScale);
    }
}
