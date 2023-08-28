using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoCrabScript : MonoBehaviour
{
    public Rigidbody2D[] crabParts;
    public SpriteRenderer sprite;
    public float pogoCharge;
    public AudioSource boing;
    public bool ignoreControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressHandler.controls.Crab.Jump.ReadValue<float>() > 0 && !ignoreControls)
        {
            pogoCharge += 1 * Time.deltaTime;
            if (pogoCharge > 5) pogoCharge = 5;
        }
        sprite.color = Color.white * 1f / pogoCharge;
        sprite.color = new Color(sprite.color.r, sprite.color.b, sprite.color.g, 255);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pogoCharge > 0)
        {
            Vector2 direction = collision.GetContact(0).normal;
            float speed = collision.relativeVelocity.magnitude;
            boing.volume = (pogoCharge / 25) + speed / 25;
            boing.pitch = 1.25f - pogoCharge * 0.1f;
            boing.Play();
            foreach (Rigidbody2D part in crabParts)
            {
                part.velocity += direction * speed * pogoCharge * 0.45f;
                pogoCharge -= 0.5f;
                if (pogoCharge < 0) pogoCharge = 0;
            }
            pogoCharge = 0;
        }
    }
}
