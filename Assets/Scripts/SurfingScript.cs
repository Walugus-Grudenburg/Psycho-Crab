using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfingScript : MonoBehaviour
{
    Rigidbody2D surfingRigidBody;
    bool isUnderwater;
    public float minimumSurfingSpeed;
    public float maximumSurfingSpeed;
    public float surfingHeightMultiplier;
    public AudioSource splashSound;
    // Start is called before the first frame update
    void Start()
    {
        surfingRigidBody = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("SurfUpwards", 0f, Random.Range(0.11f, 0.88f));
    }

    void SurfUpwards()
    {
        if (isUnderwater)
        {
            float velocityY = surfingRigidBody.velocity.y;
            float velocityX = surfingRigidBody.velocity.x;
            if (velocityY <= -4)
            {
                velocityY += Random.Range(9.33f, 23.66f) * surfingHeightMultiplier;
                if (splashSound)
                {
                    splashSound.pitch = 1.1f - (velocityY / 10);
                    splashSound.Play();
                }
            }
            velocityX += Random.Range(minimumSurfingSpeed, maximumSurfingSpeed);
            surfingRigidBody.velocity = new Vector2(velocityX, velocityY);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") || collision.CompareTag("Sulfuric Water"))
        {
            isUnderwater = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") || collision.CompareTag("Sulfuric Water"))
        {
            isUnderwater = false;
        }
    }
}
