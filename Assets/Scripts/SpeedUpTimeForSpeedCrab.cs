using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedUpTimeForSpeedCrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SPC World 1")
            Time.timeScale = 2f;
        else
            Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
