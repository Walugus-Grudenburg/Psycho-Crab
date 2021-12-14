using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public bool IsProcessingVictory;
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

    IEnumerator Victory()
    {
        if (IsProcessingVictory) yield return null;
        IsProcessingVictory = true;
        Destroy(Satan);

        yield return new WaitForSeconds(1);
        Destroy(Sushi);
        CrunchText.SetActive(true);

        yield return new WaitForSeconds(2);
        UnlockText1.SetActive(true);
        ProgressHandler.SetUnlockBC(true);

        yield return new WaitForSeconds(2);
        Destroy(UnlockText1);
        UnlockText2.SetActive(true);
        ProgressHandler.SetUnlockGC(true);

        yield return new WaitForSeconds(2);
        Destroy(UnlockText2);

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && SatanScript.HasChaseStarted)
        {
            StartCoroutine("Victory");
        }
    }

}
