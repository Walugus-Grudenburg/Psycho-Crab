using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;

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
    public string WinHandlerToCall;
    static int NumberOfWins;
    static int BCNumberOfWins;
    static int DCNumberOfWins;
    static int DRCNumberOfWins;
    static int FCNumberOfWins;
    static int GCNumberOfWins;
    static int PHCNumberOfWins;
    static int SCNumberOfWins;
    static int RCNumberOfWins;
    // Start is called before the first frame update
    void Start()
    {
        SteamUserStats.GetStat("wins", out NumberOfWins);
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
        StartCoroutine(WinHandlerToCall, 0f);
        IsProcessingVictory = true;
        Destroy(Satan);
        SatanScript.HasChaseStarted = false;
        ProgressHandler.DeTermination = true;
        NumberOfWins++;
        SteamUserStats.SetStat("wins", NumberOfWins);
        SteamUserStats.StoreStats();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && SatanScript.HasChaseStarted)
        {
            StartCoroutine("Victory", 0f);
        }
    }

    IEnumerator BCWinHandler()
    {
        BCNumberOfWins++;
        SteamUserStats.SetStat("BC_wins", BCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator DCWinHandler()
    {
        DCNumberOfWins++;
        SteamUserStats.SetStat("DC_wins", DCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator DRCWinHandler()
    {
        DRCNumberOfWins++;
        SteamUserStats.SetStat("DRC_wins", DRCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator FCWinHandler()
    {
        FCNumberOfWins++;
        SteamUserStats.SetStat("FC_wins", FCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator GCWinHandler()
    {
        GCNumberOfWins++;
        SteamUserStats.SetStat("GC_wins", GCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator PHCWinHandler()
    {
        PHCNumberOfWins++;
        SteamUserStats.SetStat("PHC_wins", PHCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator SCWinHandler()
    {
        SCNumberOfWins++;
        SteamUserStats.SetStat("SC_wins", SCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator RCWinHandler()
    {
        RCNumberOfWins++;
        SteamUserStats.SetStat("RC_wins", RCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }
}
