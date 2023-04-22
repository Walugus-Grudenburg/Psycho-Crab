using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggleScriptRandom : MonoBehaviour
{
    public float degreesToRotate = 90f;
    public float rotateTime = 1f;
    public float returnTime = 1f;
    public float minExtraDelay = 0.5f;
    public float maxExtraDelay = 1.5f;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        StartCoroutine(RotateAndReturnCoroutine());
    }

    IEnumerator RotateAndReturnCoroutine()
    {
        while (true)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, degreesToRotate);
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / rotateTime;
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                yield return null;
            }

            float extraDelay = Random.Range(minExtraDelay, maxExtraDelay);
            yield return new WaitForSeconds(extraDelay);

            Quaternion returnRotation = transform.rotation;
            t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / returnTime;
                transform.rotation = Quaternion.Lerp(returnRotation, originalRotation, t);
                yield return null;
            }
        }
    }
}
