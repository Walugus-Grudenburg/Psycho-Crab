using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject crab;
    public float targetDistance = 100f;

    void Update()
    {
        if (Vector3.Distance(this.transform.position, crab.transform.position)<=targetDistance) transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
