using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateForTimeWhenTriggered : MonoBehaviour
{
    public GameObject Object;
    public float Time;
    public bool DeleteAfterUse;
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
        if (collision.CompareTag("Player")) {
            Object.SetActive(true);
            StartCoroutine(DeactivateAfterTime(Time));
        }
    }
    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Object.SetActive(false);
        if (DeleteAfterUse)
        {
            Destroy(gameObject.GetComponent<ActivateForTimeWhenTriggered>());
        }
    }
}
