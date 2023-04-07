using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using Steamworks;

public class ProgressHandler : MonoBehaviour
{
    public static Controls controls;
    public static Vector3 Checkpoint_Position;
    public bool IgnoreControls;
    public bool ActivateDeTermination;
    public bool ResetLate;
    public CrabLeg[] Legs;
    public LoadGame loader;
    public GameObject[] Moneys;
    public GameObject SignToRotate;
    public static int BossStage;
    public static string SceneToLoad;
    public static bool DeTermination;
    public static bool JumpUnlocked;
    public static bool Spookify;
    public static bool MoneyUnlocked;
    public static bool BatcrabUnlocked;
    public static bool GullcrabUnlocked;
    public static bool DizzyCrabUnlocked;
    public static bool PrehistoricCrabUnlocked;
    public static bool SantaCrabUnlocked;
    public static bool SpiderCrabUnlocked;
    public static bool DementiaCrabUnlocked;
    public static int RCFarthestCheckpoint;
    public static int DCFarthestCheckpoint;
    public static int DRCFarthestCheckpoint;
    public static int BCFarthestCheckpoint;
    public static int SCFarthestCheckpoint;
    public static int FCFarthestCheckpoint;
    public static int GCFarthestCheckpoint;
    public static int PHCFarthestCheckpoint;
    public static int SPCFarthestCheckpoint;
    public static int RKCFarthestCheckpoint;
    public static int SDCFarthestCheckpoint;
    public static int DMCFarthestCheckpoint;
    private static bool HasDataSaved;
    static int HasDefiedDeath;
    static int AllOriginalUnlocks;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Controls();
        controls.Enable();
        LoadProgressData();
        if (!HasDataSaved)
        {
            ResetProgressToDefault();
        }
        if (LoadGame.IsContinuing)
        {
            ResetLate = true;
        }
        if (MoneyUnlocked)
        {
            foreach (GameObject Money in Moneys)
            {
                Money.SetActive(true);
            }
            if (SignToRotate) SignToRotate.transform.Rotate(0, 0, 180);
        }
        if (SteamManager.Initialized)
        {
            SteamUserStats.GetStat("Has_Defied_Death", out HasDefiedDeath);
            SteamUserStats.GetStat("All_Original_Unlocks", out AllOriginalUnlocks);
        }
        if (AllOriginalUnlocks == 0)
        {
            if (BatcrabUnlocked && DizzyCrabUnlocked && GullcrabUnlocked && JumpUnlocked && PrehistoricCrabUnlocked && SantaCrabUnlocked)
            {
                AllOriginalUnlocks = 1;
                SteamUserStats.SetStat("All_Original_Unlocks", AllOriginalUnlocks);
                SteamUserStats.StoreStats();
            }
        }
    }
    void Update()
    {
        if (ActivateDeTermination)
        {
            DeTermination = true;
            ActivateDeTermination = false;
        }
        if (controls.Crab.Reset.triggered && !IgnoreControls)
        {
            Reset(true);
        }

        if (controls.UI.C.ReadValue<float>() > 0 && controls.UI.R.ReadValue<float>() > 0 && controls.UI.A.ReadValue<float>() > 0 && controls.UI.B.ReadValue<float>() > 0)
        {
            UnlockEverything();
        }
    }

    private void LateUpdate()
    {
        if (ResetLate)
        {
            ResetLate = false;
            Reset(true);
        }
    }

    private void UnlockEverything() 
    {
        JumpUnlocked = true;
        MoneyUnlocked = true;
        BatcrabUnlocked = true;
        GullcrabUnlocked = true;
        DizzyCrabUnlocked = true;
        PrehistoricCrabUnlocked = true;
        SantaCrabUnlocked = true;
        SpiderCrabUnlocked = true;
        RCFarthestCheckpoint = 31;
        DCFarthestCheckpoint = 31;
        DRCFarthestCheckpoint = 31;
        BCFarthestCheckpoint = 31;
        SCFarthestCheckpoint = 31;
        FCFarthestCheckpoint = 31;
        GCFarthestCheckpoint = 31;
        PHCFarthestCheckpoint = 31;
        SPCFarthestCheckpoint = 31;
        RKCFarthestCheckpoint = 31;
        SDCFarthestCheckpoint = 31;
        DMCFarthestCheckpoint = 31;
        SaveProgressData();
    }

    public void Reset(bool OverrideDeTermination = false)
    {
        if (DeTermination && !OverrideDeTermination)
        {
            if (HasDefiedDeath == 0)
            {
                HasDefiedDeath = 1;
                SteamUserStats.SetStat("HasDefiedDeath", HasDefiedDeath);
                SteamUserStats.StoreStats();
            }
            return;
        }
        Teleport(Checkpoint_Position);
        
        if (SatanScript.HasChaseStarted)
        {
            SatanScript.HasChaseStarted = false;
            loader.LoadLevel();
        }
    }

    public void Teleport(Vector3 Position)
    {
        gameObject.transform.position = Position;
        foreach (CrabLeg leg in Legs)
        {
            if (leg.stickjoint)
            {
                leg.Unstick(null);
            }
        }

    }

    public static void SaveProgressData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/ResetData.dat");
        ResetData data = new ResetData();
        data.SavedCheckpointPositionX = Checkpoint_Position.x;
        data.SavedCheckpointPositionY = Checkpoint_Position.y;
        data.JumpUnlocked = JumpUnlocked;
        data.MoneyUnlocked = MoneyUnlocked;
        data.GullcrabUnlocked = GullcrabUnlocked;
        data.BatcrabUnlocked = BatcrabUnlocked;
        data.SceneToLoad = SceneToLoad;
        data.DizzycrabUnlocked = DizzyCrabUnlocked;
        data.PrehistoricCrabUnlocked = PrehistoricCrabUnlocked;
        data.SantaCrabUnlocked = SantaCrabUnlocked;
        data.SpiderCrabUnlocked = SpiderCrabUnlocked;
        data.DementiaCrabUnlocked = DementiaCrabUnlocked;
        data.BossStage = BossStage;
        data.RCFarthestCheckpoint = RCFarthestCheckpoint;
        data.BCFarthestCheckpoint = BCFarthestCheckpoint;
        data.DCFarthestCheckpoint = DCFarthestCheckpoint;
        data.DRCFarthestCheckpoint = DRCFarthestCheckpoint;
        data.FCFarthestCheckpoint = FCFarthestCheckpoint;
        data.GCFarthestCheckpoint = GCFarthestCheckpoint;
        data.PHCFarthestCheckpoint = PHCFarthestCheckpoint;
        data.SCFarthestCheckpoint = SCFarthestCheckpoint;
        data.SPCFarthestCheckpoint = SPCFarthestCheckpoint;
        data.RKCFarthestCheckpoint = RKCFarthestCheckpoint;
        data.SDCFarthestCheckpoint = SDCFarthestCheckpoint;
        data.DMCFarthestCheckpoint = DMCFarthestCheckpoint;
        formatter.Serialize(file, data);
        file.Close();
    }

    public static void LoadProgressData()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/ResetData.dat"))
        {
            HasDataSaved = true;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/ResetData.dat", FileMode.Open);
            ResetData data = (ResetData)formatter.Deserialize(file);
            Checkpoint_Position = new Vector3(data.SavedCheckpointPositionX, data.SavedCheckpointPositionY, 0);
            JumpUnlocked = data.JumpUnlocked;
            MoneyUnlocked = data.MoneyUnlocked;
            GullcrabUnlocked = data.GullcrabUnlocked;
            BatcrabUnlocked = data.BatcrabUnlocked;
            SceneToLoad = data.SceneToLoad;
            DizzyCrabUnlocked = data.DizzycrabUnlocked;
            PrehistoricCrabUnlocked = data.PrehistoricCrabUnlocked;
            SantaCrabUnlocked = data.SantaCrabUnlocked;
            SpiderCrabUnlocked = data.SpiderCrabUnlocked;
            DementiaCrabUnlocked = data.DementiaCrabUnlocked;
            BossStage = data.BossStage;
            RCFarthestCheckpoint = data.RCFarthestCheckpoint;
            BCFarthestCheckpoint = data.BCFarthestCheckpoint;
            DCFarthestCheckpoint = data.DCFarthestCheckpoint;
            DRCFarthestCheckpoint = data.DRCFarthestCheckpoint;
            FCFarthestCheckpoint = data.FCFarthestCheckpoint;
            GCFarthestCheckpoint = data.GCFarthestCheckpoint;
            PHCFarthestCheckpoint = data.PHCFarthestCheckpoint;
            SCFarthestCheckpoint = data.SCFarthestCheckpoint;
            SPCFarthestCheckpoint = data.SPCFarthestCheckpoint;
            RKCFarthestCheckpoint = data.RKCFarthestCheckpoint;
            SDCFarthestCheckpoint = data.SDCFarthestCheckpoint;
            DMCFarthestCheckpoint = data.DMCFarthestCheckpoint;
            file.Close();
        }
        else
        {
            HasDataSaved = false;
        }
    }

    public static void ResetProgressToDefault()
    {
        JumpUnlocked = false;
        MoneyUnlocked = false;
        BatcrabUnlocked = false;
        GullcrabUnlocked = false;
        DizzyCrabUnlocked = false;
        PrehistoricCrabUnlocked = false;
        SantaCrabUnlocked = false;
        SpiderCrabUnlocked = false;
        RCFarthestCheckpoint = 0;
        DCFarthestCheckpoint = 0;
        DRCFarthestCheckpoint = 0;
        BCFarthestCheckpoint = 0;
        SCFarthestCheckpoint = 0;
        FCFarthestCheckpoint = 0;
        GCFarthestCheckpoint = 0;
        PHCFarthestCheckpoint = 0;
        SPCFarthestCheckpoint = 0;
        RKCFarthestCheckpoint = 0;
        SDCFarthestCheckpoint = 0;
        DMCFarthestCheckpoint = 0;
        BossStage = 0;
        SceneToLoad = "World 1";
        SaveProgressData();
    }

    public static void SetUnlockJumping(bool value)
    {
        JumpUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockMoney(bool value)
    {
        MoneyUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockGC(bool value)
    {
        GullcrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockBC(bool value)
    {
        BatcrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockDC(bool value)
    {
        DizzyCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockPHC(bool value)
    {
        PrehistoricCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockSC(bool value)
    {
        SantaCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockSDC(bool value)
    {
        SpiderCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockDMC(bool value)
    {
        DementiaCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetBossStage(int value)
    {
        BossStage = value;
        SaveProgressData();
    }

    public static void SetBCFarthestCheckpoint(int value)
    {
        BCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetDCFarthestCheckpoint(int value)
    {
        DCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetDRCFarthestCheckpoint(int value)
    {
        DRCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetFCFarthestCheckpoint(int value)
    {
        FCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetGCFarthestCheckpoint(int value)
    {
        GCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetPHCFarthestCheckpoint(int value)
    {
        PHCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetRCFarthestCheckpoint(int value)
    {
        RCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetRKCFarthestCheckpoint(int value)
    {
        RKCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetSCFarthestCheckpoint(int value)
    {
        SCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetSPCFarthestCheckpoint(int value)
    {
        SPCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void SetSDCFarthestCheckpoint(int value)
    {
        SDCFarthestCheckpoint = value;
        SaveProgressData();
    }

    public static void ToggleSpookify()
    {
        Spookify = !Spookify;
    }

    public static void ResetCheckpointData()
    {
        Checkpoint_Position = new Vector3(0, 5, 0);
        MoneyUnlocked = false;
        BossStage = 0;
    }
}

[Serializable]
public class ResetData
{
    public float SavedCheckpointPositionX;
    public float SavedCheckpointPositionY;
    public bool JumpUnlocked;
    public bool MoneyUnlocked;
    public bool BatcrabUnlocked;
    public bool GullcrabUnlocked;
    public bool DizzycrabUnlocked;
    public bool PrehistoricCrabUnlocked;
    public bool SantaCrabUnlocked;
    public bool SpiderCrabUnlocked;
    public bool DementiaCrabUnlocked;
    public int RCFarthestCheckpoint;
    public int DCFarthestCheckpoint;
    public int DRCFarthestCheckpoint;
    public int BCFarthestCheckpoint;
    public int SCFarthestCheckpoint;
    public int SPCFarthestCheckpoint;
    public int FCFarthestCheckpoint;
    public int GCFarthestCheckpoint;
    public int PHCFarthestCheckpoint;
    public int RKCFarthestCheckpoint;
    public int SDCFarthestCheckpoint;
    public int DMCFarthestCheckpoint;
    public string SceneToLoad;
    public int BossStage;
}
