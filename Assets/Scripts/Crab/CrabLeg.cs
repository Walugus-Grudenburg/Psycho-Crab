using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabLeg : MonoBehaviour
{

    public HingeJoint2D stickjoint; // The joint for sticking when the claw is sticking
    float moveforce;
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

    IEnumerator StickAfterTime(float time) // Allows unsticking after a time in seconds
    {
        if (IsWaitingToStick)
            yield break;

        IsWaitingToStick = true;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        stickjoint.autoConfigureConnectedAnchor = false; // Disables auto reconfigure now that joint is settled
        IsWaitingToStick = false;
        IsUnstickReady = true;
    }

    IEnumerator UnStickAfterTime(float time) // Allows sticking after a time in seconds
    {
        if (IsWaitingToUnStick)
            yield break;

        IsWaitingToUnStick = true;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        IsWaitingToUnStick = false;
        IsSticking = false;
    }

    void  SticktoCollisionFirst(Collision2D collision) // Creates the joint for sticking
    {
        stickjoint = gameObject.AddComponent<HingeJoint2D>(); // Creates a hinge joint
        stickjoint.enableCollision = true; // Enables collision with object
        stickjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>(); // Connects the hinge joint to the other object
        stickjoint.anchor = gameObject.transform.InverseTransformPoint(collision.GetContact(0).point); // Changes the anchor to the collison point
    }

    void Stick(Collision2D collision, AudioSource sound, float pitchmulti = 1f)
    {
        SticktoCollisionFirst(collision);
        // Activates a stickdetector script if attatched
        StickDetector stickdetector = collision.gameObject.GetComponent<StickDetector>();
        if (stickdetector)
        {
            stickdetector.Detected = true;
        }

        // Plays the sound
        sound.pitch = pitchmulti;
        sound.Play();

        StartCoroutine(StickAfterTime(0.25f));
        IsSticking = true;

        // Sets strength based on object it's sticking to
        // 0 is weakest and unsuitable for movement
        // 1 is way stronger though a little weak for vertical climbing
        // 2 is even stronger, enough to easily climb vertically
        // 3 is about halfway between 0 and 1, strong enough to make some jumps
        switch (collision.gameObject.tag)
        {
            default:
                BoostStrength = 0;
                break;

            case "Terrain":
                BoostStrength = 1;
                break;

            case "Vertical Terrain":
                BoostStrength = 2;
                break;

            case "Area Child":
                BoostStrength = 3;
                break;

            case "Cutscene NPC":
                BoostStrength = 3;
                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        moveforce = 1;
        IsWaitingToStick = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetButtonDown("Joystick Click 0") & IsLeftLeg) || (Input.GetButtonDown("Joystick Click 1") & IsLeftLeg == false)) & IsUnstickReady) // Checks if stick is pressed
        {
                Unstick(sticksound);
        }
        if (Input.GetButtonDown("Reset Button"))
        {
            StopAllCoroutines();
            Unstick(sticksound);
        }

        if (IsLeftLeg)
        {
            float boostforce = 1f;
            // Rotates the leg in the direction of Left Stick
            if (BoostStrength == 0) boostforce = 604.8f; // Sets the force to the joystick direction
            else if (BoostStrength == 1) boostforce = 4748f; // Increases the force if the leg is boosted
            else if (BoostStrength == 2) boostforce = 6233f; // Increases it more for bigger boost
            else if (BoostStrength == 3) boostforce = 3508f; // Increase it less for riding despawnables
            moveforce = Mathf.Clamp(-Input.GetAxis("Joystick X0") - Input.GetAxis("Joystick Y0"), -1 , 1) * Time.deltaTime * boostforce;
            if (IsInGoo) moveforce /= 2;
            rb2d.AddTorque(moveforce, ForceMode2D.Impulse);
        }
        else
        {
            float boostforce = 1f;
            // Rotates the leg in the direction of Right Stick
            if (BoostStrength == 0) boostforce = 604.8f; // Sets the force to the joystick direction
            else if (BoostStrength == 1) boostforce = 4748f;  // Increases the force if the leg is boosted
            else if (BoostStrength == 2) boostforce = 6233f; // Increases it more for bigger boost
            else if (BoostStrength == 3) boostforce = 3508f; // Increase it less for riding despawnables
            moveforce = Mathf.Clamp(-Input.GetAxis("Joystick X1") + Input.GetAxis("Joystick Y1"), -1 , 1) * Time.deltaTime * boostforce; 
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
            if (hinges.Length > 1) for (int i = 1; i < hinges.Length;) Destroy(hinges[i]);
        }
        else if (stickjoint == null)
        {
            BoostStrength = 0;
            UnStickAfterTime(0);
            HingeJoint2D[] hinges = GetComponents<HingeJoint2D>();
            if (hinges.Length > 1) for (int i = 1; i < hinges.Length;) Destroy(hinges[i]);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water")) // Checks if underwater, and if so, play the sound
        {
            wetsound.pitch = 0.5f;
            wetsound.Play();
        }
        if (collision.CompareTag("Goo")) // Same with goo
        {
            IsInGoo = true;
            wetsound.pitch = 0.1f;
            wetsound.Play();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") & IsUnstickReady) // Checks if underwater, and if so, stop sticking
        {
            Unstick(wetsound);
        }
        if (collision.CompareTag("Goo"))
        {
            IsInGoo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goo")) {
            IsInGoo = false;
        }
    }

    void Unstick(AudioSource sound)
    {
        IsUnstickReady = false;
        if (stickjoint) {
            Destroy(stickjoint);
            sound.pitch = 0.75f;
            sound.Play();
        }
        StartCoroutine(UnStickAfterTime(0.25f));
    }
}
