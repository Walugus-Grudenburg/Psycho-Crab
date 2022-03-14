using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaping_Rock : MonoBehaviour
{
    public float JumpForce;
    public float JumpFrequency;
    public GameObject Player;
    public int DeactivateDistance;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Jump",0f,JumpFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Jump()
    {
        if (!Player || Vector2.Distance(Player.transform.position, gameObject.transform.position) <= DeactivateDistance)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * JumpForce);
        }
    }
}
