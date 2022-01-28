using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackReturnAfterTime : MonoBehaviour
{
    public float Time;
    public BossAttack Attack;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Return",Time);
    }

    void Return()
    {
        Attack.Return();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
