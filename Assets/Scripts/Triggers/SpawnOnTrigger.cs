using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float cooldownTime = 5f;
    private float lastSpawnTime = -999f; // Set to a very negative number to ensure the first spawn happens immediately

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time - lastSpawnTime >= cooldownTime)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
