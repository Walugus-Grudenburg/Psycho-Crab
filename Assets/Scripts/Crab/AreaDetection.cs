using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetection : MonoBehaviour
{
    public Camera Cam;
    public float ZoomAmount;
    public SpriteRenderer[] ObjectsToDarkenInDarkAreas;
    public GameObject[] ObjectsToDisableInDarkAreas;
    public GameObject PostProcessingForDarkAreas;
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
        if (collision.CompareTag("Area Parent") || collision.CompareTag("Camera Zoom"))
        {
            Cam.orthographicSize += ZoomAmount;
        }
        else if (collision.CompareTag("Dark Area"))
        {
            foreach (SpriteRenderer objectToDarken in ObjectsToDarkenInDarkAreas)
            {
                objectToDarken.color = new Color(0.2f, 0.2f, 0.2f);
            }

            foreach (GameObject gameobject in ObjectsToDisableInDarkAreas)
            {
                gameobject.SetActive(false);
            }

            PostProcessingForDarkAreas.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Area Detection"))
        {
            AudioSource audiosrc = collision.GetComponent<AudioSource>();
            if (audiosrc != null)
            {
                audiosrc.volume = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area Detection"))
        {
            AudioSource audiosrc = collision.GetComponent<AudioSource>();
            if (audiosrc != null)
            {
                audiosrc.volume = 0;
            }
        }
        else if (collision.CompareTag("Area Parent") || collision.CompareTag("Camera Zoom"))
        {
            Cam.orthographicSize -= ZoomAmount;
        }
        else if (collision.CompareTag("Dark Area"))
        {
            foreach (SpriteRenderer objectToDarken in ObjectsToDarkenInDarkAreas)
            {
                objectToDarken.color = Color.white;
            }

            foreach (GameObject gameobject in ObjectsToDisableInDarkAreas)
            {
                gameobject.SetActive(true);
            }

            PostProcessingForDarkAreas.SetActive(false);
        }
    }
}
