using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWhenUnlocked : MonoBehaviour
{
    public enum Condition {JumpUnlocked};
    public bool IsSoft;
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
            if (!ProgressHandler.JumpUnlocked || !IsSoft)
            { 
                ObjectToToggle.SetActive(ProgressHandler.JumpUnlocked);
            }
        } 
    }
}
