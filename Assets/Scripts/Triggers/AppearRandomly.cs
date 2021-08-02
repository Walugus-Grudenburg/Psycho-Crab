using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearRandomly : MonoBehaviour
{
    public float seconds;
    public int RandomChanceDenominator;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomCheck(seconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomCheck(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(RandomCheck(seconds));
        if (Random.Range(0, RandomChanceDenominator) == 1)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
