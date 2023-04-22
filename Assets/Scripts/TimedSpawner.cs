using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;   // The object to spawn
    public float spawnInterval;        // Time in seconds between spawns
    public int numberOfChildren;       // Maximum number of children to spawn

    private int currentNumberOfChildren = 0;  // Current number of spawned children
    private float timer = 0f;                  // Timer for spawning

    private void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we've spawned enough children
        if (currentNumberOfChildren >= numberOfChildren)
        {
            return;
        }

        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new child
        if (timer >= spawnInterval)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        // Reset the timer
        timer = 0f;

        // Spawn a new child object
        GameObject child = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Make the child object a child of this object
        child.transform.parent = transform;

        // Increment the current number of children
        currentNumberOfChildren++;
    }
}
