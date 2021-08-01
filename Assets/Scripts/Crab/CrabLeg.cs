using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabLeg : MonoBehaviour
{

    HingeJoint2D stickjoint; // The joint for sticking when the claw is sticking
    float moveforce; // Force to move with when moving
    public bool IsLeftLeg;
    Rigidbody2D rb2d;
    public AudioSource sticksound;
    public AudioSource wetsound;
    bool IsSticking;
    bool IsUnstickReady;
    float BoostStrength;
    private bool IsWaitingToStick;
    private bool IsWaitingToUnStick;
    private bool IsInGoo;
    IEnumerator StickAfterTime(float time) // Sticks after a time in seconds
    {
        if (IsWaitingToStick)
            yield break;

        IsWaitingToStick = true;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        IsWaitingToStick = false;
        IsUnstickReady = true;
    }
    IEnumerator UnStickAfterTime(float time) // Unsticks after a time in seconds
    {
        if (IsWaitingToUnStick)
            yield break;

        IsWaitingToUnStick = true;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        IsWaitingToUnStick = false;
        IsSticking = false;
    }
    void  SticktoCollisionFirst(Collision2D collision) // Sticks to the first object in a collision
    {
        stickjoint = gameObject.AddComponent<HingeJoint2D>(); // Creates a hinge joint
        stickjoint.enableCollision = true; // Enables collision with object
        stickjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>(); // Connects the hinge joint to the other object
        stickjoint.anchor = gameObject.transform.InverseTransformPoint(collision.GetContact(0).point); // Changes the anchor to the collison point
    }
    void Stick(Collision2D collision, AudioSource sound, float pitchmulti = 1f)
    {
        SticktoCollisionFirst(collision);
        IsSticking = true;
        sound.pitch = pitchmulti;
        sound.Play();
        StartCoroutine(StickAfterTime(0.25f));
        if (collision.gameObject.CompareTag("Terrain"))
        {
            BoostStrength = 1;
        }
        if (collision.gameObject.CompareTag("Vertical Terrain"))
        {
            BoostStrength = 2;
        }
        if (collision.gameObject.CompareTag("Area Child"))
        {
            BoostStrength = 3;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        moveforce = 1;
        IsWaitingToStick = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frames
    void Update()
    {
        if (((Input.GetButtonDown("Joystick Click 0") & IsLeftLeg) || (Input.GetButtonDown("Joystick Click 1") & IsLeftLeg == false)) & IsUnstickReady) // Checks if stick is pressed
        {
                Unstick(sticksound);
        }

        if (IsLeftLeg)
        {
            float boostforce = 1f;
            // Rotates the leg in the direction of Left Stick
            if (BoostStrength == 0) boostforce = 404.8f; // Sets the force to the joystick direction
            else if (BoostStrength == 1) boostforce = 3548f; // Increases the force if the leg is boosted
            else if (BoostStrength == 2) boostforce = 4233f; // Increases it more for bigger boost
            else if (BoostStrength == 3) boostforce = 1808f; // Increase it less for riding despawnables
            moveforce = (Mathf.Max(-Input.GetAxis("Joystick X0") - Input.GetAxis("Joystick Y0")) * Time.deltaTime * boostforce);
            if (IsInGoo) moveforce /= 2;
            rb2d.AddTorque(moveforce, ForceMode2D.Impulse);
        }
        else
        {
            float boostforce = 1f;
            // Rotates the leg in the direction of Right Stick
            if (BoostStrength == 0) boostforce = 404.8f; // Sets the force to the joystick direction
            else if (BoostStrength == 1) boostforce = 3548f;  // Increases the force if the leg is boosted
            else if (BoostStrength == 2) boostforce = 4233f; // Increases it more for bigger boost
            else if (BoostStrength == 3) boostforce = 1808f; // Increase it less for riding despawnables
            moveforce = (Mathf.Max(-Input.GetAxis("Joystick X1") + Input.GetAxis("Joystick Y1")) * Time.deltaTime * boostforce); 
            if (IsInGoo) moveforce /= 2;
            rb2d.AddTorque(moveforce, ForceMode2D.Impulse);
        }
    }
    // OnCollisionStay is called once per frame while objects are colliding
    void OnCollisionStay2D(Collision2D collision)
    {
        if (IsSticking == false)
        {
            if ((Input.GetButton("Joystick Click 0") & IsLeftLeg) || (Input.GetButton("Joystick Click 1") & IsLeftLeg == false)) // Checks if stick is pressed
            {
                if (collision.gameObject.CompareTag("Player") == false) // Checks that the object isn't a player
                {
                    Stick(collision, sticksound);
                }
            }
            if (IsInGoo & !collision.gameObject.CompareTag("Player"))  
            {
                Stick(collision, sticksound, 0.5f);
                wetsound.pitch = 0.05f;
                wetsound.Play();
            }
        }
    }
    // LateUpdate is called every frame, after Update
    void LateUpdate()
    {
        if (IsSticking == false) 
        {
            BoostStrength = 0;
            if (stickjoint!= null) Destroy(stickjoint);
            HingeJoint2D[] hinges = GetComponents<HingeJoint2D>();
            if (hinges.Length > 1) for (int i = 1; i < hinges.Length; i++) Destroy(hinges[i]);
        }
        else if (stickjoint == null)
        {
            UnStickAfterTime(0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water")) // Checks if underwater, and if so, play the sound
        {
            wetsound.pitch = 0.5f;
            wetsound.Play();
        }
        if (collision.gameObject.CompareTag("Goo"))
        {
            IsInGoo = true;
            wetsound.pitch = 0.1f;
            wetsound.Play();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water") & IsUnstickReady) // Checks if underwater, and if so, stop sticking
        {
            Unstick(wetsound);
        }
        if (collision.gameObject.CompareTag("Goo"))
        {
            IsInGoo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInGoo = false;
    }
    void Unstick(AudioSource sound)
    {
            Destroy(stickjoint);
            IsUnstickReady = false;
            sound.pitch = 0.75f;
            sound.Play();
            StartCoroutine(UnStickAfterTime(0.25f));
    }
}
