using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    public SpriteRenderer[] spritesToColorChange;
    public Color shieldColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        foreach (SpriteRenderer sprite in spritesToColorChange)
        {
            sprite.color = shieldColor;
        }
        ProgressHandler.DeTermination = true;
        StartCoroutine("DisableWhenDone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableWhenDone()
    {
        yield return new WaitForSeconds(Random.Range(6,12));
        foreach (SpriteRenderer sprite in spritesToColorChange)
        {
            sprite.color = Color.white;
        }
        ProgressHandler.DeTermination = false;
        gameObject.SetActive(false);
    }
}
