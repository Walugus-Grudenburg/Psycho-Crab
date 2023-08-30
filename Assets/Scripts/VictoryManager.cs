using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;

public class VictoryManager : MonoBehaviour
{
    public bool DoVictoryDance = true;
    public bool IsProcessingVictory;
    public bool DoUnlock1;
    public bool DoUnlock2;
    public bool DoUnlock3;
    public bool DoUnlock4;
    public bool DoUnlock5;
    public bool DoUnlock6;
    public bool DoUnlock7;
    public bool IsSushi;
    public GameObject CrunchText;
    public GameObject Satan;
    public GameObject Sushi;
    public GameObject UnlockText1;
    public GameObject UnlockText2;
    public string WinHandlerToCall;
    static int NumberOfWins;
    // Start is called before the first frame update
    void Start()
    {
        SteamUserStats.GetStat("wins", out NumberOfWins);
        foreach (CrabClass crab in ProgressHandler.allCrabClasses)
        {
            SteamUserStats.GetStat(crab.winsStatName, out crab.numberOfWins);
        }
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
        if (IsProcessingVictory) yield break;
        CrabClass crab = null;
        foreach (CrabClass crab2 in ProgressHandler.allCrabClasses)
        {
            if (crab2.name == WinHandlerToCall)
            {
                crab = crab2;
                break;
            }
        }
        IsProcessingVictory = true;
        Destroy(Satan);
        SatanScript.HasChaseStarted = false;
        ProgressHandler.DeTermination = true;
        NumberOfWins++;
        crab.numberOfWins++;
        SteamUserStats.SetStat("wins", NumberOfWins);
        SteamUserStats.SetStat(crab.winsStatName, crab.numberOfWins);
        SteamUserStats.StoreStats();

        if (DoVictoryDance)
        {
            yield return new WaitForSeconds(1);
            Destroy(Sushi);
            CrunchText.SetActive(true);
        }
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

        if (DoUnlock5)
        {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockSDC(true);
            ProgressHandler.SetUnlockBC(true);
            ProgressHandler.SetUnlockGC(true);
        }

        if (DoUnlock6)
        {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockGLC(true);
        }

        if (DoUnlock6)
        {
            yield return new WaitForSeconds(2);
            UnlockText1.SetActive(true);
            ProgressHandler.SetUnlockPLC(true);
        }

        yield return new WaitForSeconds(2);
        Destroy(UnlockText2);

        ProgressHandler.DeTermination = false;

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (SatanScript.HasChaseStarted || IsSushi))
        {
            StartCoroutine("Victory", 0f);
        }
    }

}
