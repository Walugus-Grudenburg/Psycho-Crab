using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceWithObjectAfterTime : MonoBehaviour
{
    public bool useRandomTime;
    public bool disableInstead;
    public float timeUntilReplace;
    public float minTimeUntilReplace;
    public float maxTimeUntilReplace;
    public GameObject replacementObject;
    // Start is called before the first frame update
    void Awake()
    {
        if (useRandomTime)
        {
            timeUntilReplace = Random.Range(minTimeUntilReplace, maxTimeUntilReplace);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilReplace -= Time.deltaTime;
        if (timeUntilReplace <= 0f)
        {
            GameObject replacement = Instantiate(replacementObject, transform.position, transform.rotation);
            replacement.transform.parent = transform.parent;
            if (disableInstead)
            {
                gameObject.SetActive(false);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }

    
}
