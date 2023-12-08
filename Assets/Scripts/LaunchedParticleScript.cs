using UnityEngine;

public class LaunchedParticleScript : MonoBehaviour
{
    public float speedMinimum;
    public float speedMaximum;
    float speed;

    void Start()
    {
        // Set speed randomly between speedMinimum and speedMaximum
        speed = Random.Range(speedMinimum, speedMaximum);
        // Set random rotation at the start
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
    }

    void Update()
    {
        // Move the object forwards based "speed"
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
