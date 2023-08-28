using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaporator : MonoBehaviour
{
    public AudioSource soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") || collision.CompareTag("Goo"))
        {
            collision.gameObject.SetActive(false);
            soundToPlay.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") || collision.CompareTag("Goo"))
        {
            collision.gameObject.SetActive(false);
            soundToPlay.Play();
        }
    }
}
