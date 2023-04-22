using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutsceneNPC : MonoBehaviour
{
    public CutsceneNPC target;
    public string tagToCheck;
    public Vector2 direction;
    public float speed;
    public AudioSource audioSource;
    public bool isReady;

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
        if (isReady && collision.CompareTag(tagToCheck)) 
        {
            target.Direction = direction;
            target.Speed = speed;
            if (audioSource) audioSource.Play();
            isReady = false;
        }
    }
}
