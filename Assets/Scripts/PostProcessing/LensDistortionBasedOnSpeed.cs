using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LensDistortionBasedOnSpeed : MonoBehaviour
{
    public PostProcessVolume volume;
    PostProcessProfile profile;
    LensDistortion lensDistortion;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        profile = volume.profile;
        rb = gameObject.GetComponent<Rigidbody2D>();
        profile.TryGetSettings(out lensDistortion);
    }

    // Update is called once per frame
    void Update()
    {
        lensDistortion.intensity.value = Mathf.Max(-100f, rb.velocity.magnitude * -1.5f);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyProfile(profile, true);
    }
}
