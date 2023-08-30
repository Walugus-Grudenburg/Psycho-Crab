using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilFire : MonoBehaviour
{
    public AudioSource fireSound;
    public static bool hasFireStarted;
    // Start is called before the first frame update
    void Start()
    {
        hasFireStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && (collision.gameObject.name != "Satan"))
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>())
            {
                if (fireSound) fireSound.Play();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
