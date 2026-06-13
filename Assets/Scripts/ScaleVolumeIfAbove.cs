using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleVolumeIfAbove : MonoBehaviour
{
    public AudioSource Audio;
    public GameObject Target;
    public float ScaleFactor = 1f;
    private float targetHeight;
    private float ownHeight;
    // Start is called before the first frame update
    void Start()
    {
        if (!Audio) Audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetHeight = Target.transform.position.y;
        ownHeight = gameObject.transform.position.y;
        if (targetHeight > ownHeight)
        {
            Audio.volume = 1 / ((targetHeight - ownHeight) / ScaleFactor);
        }
        else Audio.volume = 1;
    }
}
