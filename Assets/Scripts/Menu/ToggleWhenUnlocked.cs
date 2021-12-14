using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWhenUnlocked : MonoBehaviour
{
    public enum Condition {JumpUnlocked};
    public Condition condition;
    public GameObject ObjectToToggle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (condition == Condition.JumpUnlocked)
        {
            if (!ProgressHandler.JumpUnlocked)
            { 
                ObjectToToggle.SetActive(ProgressHandler.JumpUnlocked);
            }
        } 
    }
}
