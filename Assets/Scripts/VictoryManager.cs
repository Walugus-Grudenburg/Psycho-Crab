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
    public bool IsSushi;
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
    static int SPCNumberOfWins;
    static int SDCNumberOfWins;
    static int RCNumberOfWins;
    static int RCCNumberOfWins;
    static int RKCNumberOfWins;
    static int GCCNumberOfWins;
    static int DMCNumberOfWins;
    static int DCCNumberOfWins;
    // Start is called before the first frame update
    void Start()
    {
        SteamUserStats.GetStat("wins", out NumberOfWins);
        SteamUserStats.GetStat("BC_wins", out BCNumberOfWins);
        SteamUserStats.GetStat("DC_wins", out DCNumberOfWins);
        SteamUserStats.GetStat("DRC_wins", out DRCNumberOfWins);
        SteamUserStats.GetStat("FC_wins", out FCNumberOfWins);
        SteamUserStats.GetStat("GC_wins", out GCNumberOfWins);
        SteamUserStats.GetStat("GCC_wins", out GCCNumberOfWins);
        SteamUserStats.GetStat("PHC_wins", out PHCNumberOfWins);
        SteamUserStats.GetStat("SC_wins", out SCNumberOfWins);
        SteamUserStats.GetStat("SPC_wins", out SPCNumberOfWins);
        SteamUserStats.GetStat("SDC_wins", out SDCNumberOfWins);
        SteamUserStats.GetStat("RC_wins", out RCNumberOfWins);
        SteamUserStats.GetStat("RCC_wins", out RCCNumberOfWins);
        SteamUserStats.GetStat("RKC_wins", out RKCNumberOfWins);
        SteamUserStats.GetStat("DMC_wins", out DMCNumberOfWins);
        SteamUserStats.GetStat("DCC_wins", out DCCNumberOfWins);
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

    IEnumerator GCCWinHandler()
    {
        GCCNumberOfWins++;
        SteamUserStats.SetStat("GCC_wins", GCCNumberOfWins);
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

    IEnumerator SPCWinHandler()
    {
        SPCNumberOfWins++;
        SteamUserStats.SetStat("SPC_wins", SPCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator SDCWinHandler()
    {
        SDCNumberOfWins++;
        SteamUserStats.SetStat("SDC_wins", SDCNumberOfWins);
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

    IEnumerator RCCWinHandler()
    {
        RCNumberOfWins++;
        SteamUserStats.SetStat("RCC_wins", RCCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator RKCWinHandler()
    {
        RKCNumberOfWins++;
        SteamUserStats.SetStat("RKC_wins", RKCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }

    IEnumerator DMCWinHandler()
    {
        DMCNumberOfWins++;
        SteamUserStats.SetStat("DMC_wins", DMCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }
    IEnumerator DCCWinHandler()
    {
        DCCNumberOfWins++;
        SteamUserStats.SetStat("DCC_wins", DCCNumberOfWins);
        SteamUserStats.StoreStats();
        yield return null;
    }
}
