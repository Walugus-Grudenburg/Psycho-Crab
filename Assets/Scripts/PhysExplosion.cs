using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysExplosion : MonoBehaviour
{
    public bool randomTime;
    public float minRandomTime;
    public float maxRandomTime;
    public float timeToExplode;
    public float timeOfExplosion;
    public float explosionRadius;
    public float explosionForce;
    public AudioSource explosionSound;
    public bool changeSprite;
    public bool deleteAfter;
    public Sprite spriteToChangeTo;
    public SpriteRenderer spriteToChange;
    // Start is called before the first frame update
    void Start()
    {
        if (randomTime) timeToExplode = Random.Range(minRandomTime, maxRandomTime);
        Invoke("Explode", timeToExplode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        int ignoreIgnoreRaycast = 1 << LayerMask.NameToLayer("IgnoreRaycast");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRadius, ~ignoreIgnoreRaycast,-1000,1000);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            if (rb != null && !rb.isKinematic)
                rb.AddExplosionForce2D(gameObject.transform.position, explosionForce, explosionRadius);

        }
        if (explosionSound) explosionSound.Play();
        if (changeSprite) spriteToChange.sprite = spriteToChangeTo;
        if (deleteAfter) Invoke("Delete", timeOfExplosion);
    }

    void Delete()
    {
        Destroy(gameObject);
    }

}
