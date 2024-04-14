using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenParentDisabled : MonoBehaviour
{
    void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
