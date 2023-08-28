using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWhenUnlocked : MonoBehaviour
{
    public enum Condition {JumpUnlocked,GullcrabUnlocked,BatcrabUnlocked,DizzyCrabUnlocked,PrehistoricCrabUnlocked,SantaCrabUnlocked,SpiderCrabUnlocked,DementiaCrabUnlocked, GlassCrabUnlocked};
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

        if (condition == Condition.BatcrabUnlocked)
        {
            if (!ProgressHandler.BatcrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.BatcrabUnlocked);
            }
        }

        if (condition == Condition.GullcrabUnlocked)
        {
            if (!ProgressHandler.GullcrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.GullcrabUnlocked);
            }
        }

        if (condition == Condition.DizzyCrabUnlocked)
        {
            if (!ProgressHandler.DizzyCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.DizzyCrabUnlocked);
            }
        }

        if (condition == Condition.PrehistoricCrabUnlocked)
        {
            if (!ProgressHandler.PrehistoricCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.PrehistoricCrabUnlocked);
            }
        }

        if (condition == Condition.SantaCrabUnlocked)
        {
            if (!ProgressHandler.SantaCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.SantaCrabUnlocked);
            }
        }

        if (condition == Condition.SpiderCrabUnlocked)
        {
            if (!ProgressHandler.SpiderCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.SpiderCrabUnlocked);
            }
        }

        if (condition == Condition.DementiaCrabUnlocked)
        {
            if (!ProgressHandler.DementiaCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.DementiaCrabUnlocked);
            }
        }

        if (condition == Condition.GlassCrabUnlocked)
        {
            if (!ProgressHandler.GlassCrabUnlocked)
            {
                ObjectToToggle.SetActive(ProgressHandler.GlassCrabUnlocked);
            }
        }
    }
}
