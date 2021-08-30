using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectWhenEscapeIsPressed : MonoBehaviour
{
    public GameObject[] ObjectsToToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            foreach (GameObject Object in ObjectsToToggle)
            {
                if (Object)
                {
                    Object.SetActive(!Object.activeInHierarchy);
                }
            }
        }   
    }
}
