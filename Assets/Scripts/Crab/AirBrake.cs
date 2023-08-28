using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBrake : MonoBehaviour
{
    public Rigidbody2D[] objectsToSlow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        foreach (Rigidbody2D toSlow in objectsToSlow)
        {
            toSlow.drag = 0.65f;
            toSlow.angularDrag = 0.5f;
        }
        StartCoroutine("RemoveAirBrake");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RemoveAirBrake()
    {
        yield return new WaitForSeconds(Random.Range(3,6));
        foreach (Rigidbody2D toSlow in objectsToSlow)
        {
            toSlow.drag = 0f;
            toSlow.angularDrag = 0.05f;
        }
        gameObject.SetActive(false);
    }
}
