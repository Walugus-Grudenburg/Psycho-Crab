using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherClown : MonoBehaviour
{
    public float degreesToRotate = 90f;
    public float rotateTime = 1f;
    public float waitTime = 1f;
    public float returnTime = 1f;
    public string targetTag = "Player";
    private bool isRotating = false;
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isRotating && other.CompareTag(targetTag))
        {
            StartCoroutine(RotateCoroutine());
        }
    }

    IEnumerator RotateCoroutine()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, degreesToRotate);
        float t = 0f;
        isRotating = true;

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

        isRotating = false;
    }
}
