using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public bool IsProcessingVictory;
    public bool DoUnlock1;
    public bool DoUnlock2;
    public bool DoUnlock3;
    public bool DoUnlock4;
    public GameObject CrunchText;
    public GameObject Satan;
    public GameObject Sushi;
    public GameObject UnlockText1;
    public GameObject UnlockText2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win(float time = 0f)
    {
        StartCoroutine("Victory", 5f);
    }

    IEnumerator Victory(float time = 0f)
    {
        yield return new WaitForSeconds(time);
        if (IsProcessingVictory) yield return null;
        IsProcessingVictory = true;
        Destroy(Satan);
        ProgressHandler.DeTermination = true;

        yield return new WaitForSeconds(1);
        Destroy(Sushi);
        CrunchText.SetActive(true);

        if (DoUnlock1) {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockBC(true);
        }
        if (DoUnlock2)
        {
            yield return new WaitForSeconds(2);
            Destroy(UnlockText1);
            UnlockText2.SetActive(true);
            ProgressHandler.SetUnlockGC(true);
        }

        if (DoUnlock3)
        {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockDC(true);
        }

        if (DoUnlock4)
        {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockSC(true);
        }

        yield return new WaitForSeconds(2);
        Destroy(UnlockText2);

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && SatanScript.HasChaseStarted)
        {
            StartCoroutine("Victory");
        }
    }

}
