using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeScriptsOnTrigger : MonoBehaviour
{
    public bool DestroyAfterUse;
    public MonoBehaviour[] Scripts;
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
        foreach (MonoBehaviour script in Scripts)
        {
            script.enabled = true;
        }
        if (DestroyAfterUse)
        {
            Destroy(gameObject.GetComponent<WakeScriptsOnTrigger>());
        }
    }
}
