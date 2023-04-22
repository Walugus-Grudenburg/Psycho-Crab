using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggleScript : MonoBehaviour
{
    public float degreesToRotate = 90f;
    public float rotateTime = 1f;
    public float returnTime = 1f;
    public float waitTime = 1f;
    public string tagToCheck = "Player";
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

            yield return new WaitForSeconds(waitTime);

            Quaternion returnRotation = transform.rotation;
            t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / returnTime;
                transform.rotation = Quaternion.Lerp(returnRotation, originalRotation, t);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            if (gameObject.CompareTag(tagToCheck))
            {
                // Do something when the object with the specified tag is detected
            }
        }
    }
}
