using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWhenPlayerIsClose : MonoBehaviour
{
    public GameObject FarObject;
    public GameObject CloseObject;
    public AudioSource SwapSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") & (FarObject.activeInHierarchy | FarObject.activeInHierarchy))
        {
            FarObject.SetActive(false);
            CloseObject.SetActive(true);
            SwapSound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FarObject.SetActive(true);
            CloseObject.SetActive(false);
        }
    }
}
