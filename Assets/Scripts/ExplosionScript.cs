using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float explosionTime;
    public float lionReleasingTime;
    public AudioSource explosionSound;
    public AudioSource sealionSound;
    public bool releaseLions;
    public GameObject lionSpawner;
    public GameObject[] objectsToExplode;
    public GameObject[] explosions;
    [SerializeField] private string tagToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToActivate))
        {
            explosionSound.Play();
            foreach (GameObject obj in explosions)
            {
                obj.SetActive(true);
            }
            Invoke("ExplodeObjects", explosionTime);
        }
    }

    void ExplodeObjects()
    {
        foreach (GameObject obj in objectsToExplode) 
        {
            Destroy(obj);       
        }
        if (releaseLions)
        {
            sealionSound.Play();
            Invoke("ReleaseLions", lionReleasingTime);
        }
    }

    void ReleaseLions()
    {
        lionSpawner.SetActive(true);
    }
}
