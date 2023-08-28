using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCrabScript : SpookyJump
{
    enum Gadget { None, Jetpack, PogoStick, Bomb, EnergyShield, AirBrake, SeagullBeam, Evaporator, GravityControl, PortableCheckpoint };
    Gadget gadgetToSelect;
    public int chargeCap;
    public static RoboCrabScript mainInstance;
    public static float nearestLavaDistance;
    public static GameObject nearestSeagull;
    public static float nearestSeagullDistance;
    public GameObject jetPack;
    public GameObject pogoStick;
    public PogoCrabScript pogoStickScript;
    public GameObject bombPrefab;
    public GameObject energyShield;
    public GameObject airBrake;
    public GameObject seagullBeam;
    public GameObject evaporator;
    public GameObject gravityController;
    public GameObject portableCheckpointPrefab;
    public Rigidbody2D rigidBody;
    public CrabLeg[] crabLegs;
    // Start is called before the first frame update
    void Start()
    {
        mainInstance = this;
        gadgetToSelect = Gadget.None;
        nearestLavaDistance = 999999f;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ProgressHandler.controls.Crab.Jump.triggered && Active & Charged > 0)
        {
            ActivateWeightedGadget();
        }
        else if (Recharge && Charged == 0)
        {
            Recharge = false;
            StartCoroutine(RechargeAfterTime(1 / ChargeMulti));
        }

    }

    void ActivateWeightedGadget()
    {
        CalculateWhichGadgetToUse();
        UseSelectedGadget(gadgetToSelect);
        if (!DisableCameraChanges) Cam.orthographicSize -= 2f * Charged;
        Charged = 0;
        StopAllCoroutines();
        StartCoroutine(RechargeAfterTime(4.3f - ChargeMulti * 1.3f));
    }

    protected override IEnumerator RechargeAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Charged += 1;
        if (!DisableCameraChanges) Cam.orthographicSize += 2f;
        ChargedSound.pitch = 3.5f;
        ChargedSound.Play();
        if (Charged < chargeCap)
        {
            StartCoroutine(RechargeAfterTime((1 + Charged / ChargeMulti) / ChargeMulti));
        }
    }

    void CalculateWhichGadgetToUse()
    {
        while (gadgetToSelect == Gadget.None)
        {
            if (Random.Range(0, 5) == 0)  // medium chance to just pick anything instead of running logic again
            {
                switch (Random.Range(0,9))
                {
                    case 0:
                        gadgetToSelect = Gadget.Jetpack;
                        break;
                    case 1:
                        gadgetToSelect = Gadget.AirBrake;
                        break;
                    case 2:
                        gadgetToSelect = Gadget.Bomb;
                        break;
                    case 3:
                        gadgetToSelect = Gadget.EnergyShield;
                        break;
                    case 4:
                        gadgetToSelect = Gadget.GravityControl;
                        break;
                    case 5:
                        gadgetToSelect = Gadget.PogoStick;
                        break;
                    case 6:
                        gadgetToSelect = Gadget.PortableCheckpoint;
                        break;
                    case 7:
                        gadgetToSelect = Gadget.SeagullBeam;
                        break;
                    case 8:
                        gadgetToSelect = Gadget.Evaporator;
                        break;
                    default:
                        break;
                }
                if (Random.Range(0, 10) == 0) gadgetToSelect = Gadget.Bomb;// low chance bomb
                if (Random.Range(0, 10) == 0 & GadgetGroundCheck.anyIsGrounded) gadgetToSelect = Gadget.PortableCheckpoint;// low chance portable checkpoint if grounded
                if (Random.Range(0, 10) == 0 & !GadgetGroundCheck.anyIsGrounded) gadgetToSelect = Gadget.GravityControl;// low chance gravity control if midair
                if (Random.Range(0, 5) == 0 & !GadgetGroundCheck.anyIsGrounded) gadgetToSelect = Gadget.Bomb;// medium chance bomb if midair
                if (Random.Range(0, 5) == 0 & !GadgetGroundCheck.anyIsGrounded) gadgetToSelect = Gadget.Jetpack;// medium chance jetpack if midair
                if (rigidBody.velocity.magnitude > 50 & Random.Range(0, 2) == 0) gadgetToSelect = Gadget.PogoStick;// high chance air brake if really fast
                if (rigidBody.velocity.y < -30 & Random.Range(0, 2) == 0) gadgetToSelect = Gadget.PogoStick;// high chance pogo stick if fast downwards
                if (nearestSeagullDistance < 200 & Random.Range(0, 2) == 0) gadgetToSelect = Gadget.SeagullBeam;//high chance seagull beam if seagull near
                bool isInWater = false; // needs to do some checks for evaporator logic
                bool isInGoo = false;
                foreach (CrabLeg crabLeg in crabLegs)
                {
                    if (crabLeg.IsInWater) isInWater = true;
                    if (crabLeg.IsInGoo) isInGoo = true;
                }
                if (isInWater & Random.Range(0, 2) == 0) gadgetToSelect = Gadget.Evaporator;// high chance evaporator if in water. really high if goo
                if (isInGoo & Random.Range(0, 3) < 2) gadgetToSelect = Gadget.Evaporator; // goo check
                if (nearestLavaDistance < 100 & Random.Range(0, 2) == 0) gadgetToSelect = Gadget.EnergyShield;// high chance energy shield if near lava
            }
        }
    }
    void UseSelectedGadget(Gadget gadget)
    {
        switch (gadgetToSelect)
        {
            case Gadget.None:
                break;
            case Gadget.Jetpack:
                jetPack.SetActive(true);
                break;
            case Gadget.PogoStick:
                pogoStick.SetActive(true);
                pogoStickScript.pogoCharge = 5;
                break;
            case Gadget.Bomb:
                GameObject bomb = Instantiate(bombPrefab, gameObject.transform);
                bomb.transform.parent = null;
                break;
            case Gadget.EnergyShield:
                energyShield.SetActive(true);
                break;
            case Gadget.AirBrake:
                airBrake.SetActive(true);
                break;
            case Gadget.SeagullBeam:
                seagullBeam.SetActive(true);
                break;
            case Gadget.Evaporator:
                evaporator.SetActive(true);
                break;
            case Gadget.GravityControl:
                gravityController.SetActive(true);
                break;
            case Gadget.PortableCheckpoint:
                GameObject portableCheckpoint = Instantiate(portableCheckpointPrefab, gameObject.transform);
                portableCheckpoint.transform.parent = null;
                break;
            default:
                break;
        }
        gadgetToSelect = Gadget.None;
    }

    void LateUpdate()
    {
        nearestLavaDistance = 999999f;
        nearestSeagullDistance = 999999f;
    }
}
