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
    public static ProgressHandler maininstance;
    public static Controls controls;
    public static Vector3 Checkpoint_Position;
    public bool IgnoreControls;
    public bool ActivateDeTermination;
    public bool ResetLate;
    public bool IsMainInstance = true;
    public CrabLeg[] Legs;
    public LoadGame loader;
    public GameObject[] Moneys;
    public GameObject SignToRotate;
    public static int BossStage;
    public static int GIGABossStage;
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
    public static bool GlassCrabUnlocked;
    public static bool PollutionCrabUnlocked;
    private static bool HasDataSaved;
    static int HasDefiedDeath;
    static int AllOriginalUnlocks;

    public static CrabClass[] allCrabClasses;
    public static CrabClass RCCrabClass = new CrabClass();
    public static CrabClass RCCCrabClass = new CrabClass();
    public static CrabClass DCCrabClass = new CrabClass();
    public static CrabClass DRCCrabClass = new CrabClass();
    public static CrabClass BCCrabClass = new CrabClass();
    public static CrabClass SCCrabClass = new CrabClass();
    public static CrabClass FCCrabClass = new CrabClass();
    public static CrabClass GCCrabClass = new CrabClass();
    public static CrabClass GCCCrabClass = new CrabClass();
    public static CrabClass PHCCrabClass = new CrabClass();
    public static CrabClass SPCCrabClass = new CrabClass();
    public static CrabClass RKCCrabClass = new CrabClass();
    public static CrabClass SDCCrabClass = new CrabClass();
    public static CrabClass DCCCrabClass = new CrabClass();
    public static CrabClass DMCCrabClass = new CrabClass();
    public static CrabClass PCCrabClass = new CrabClass();
    public static CrabClass GLCCrabClass = new CrabClass();
    public static CrabClass PCCCrabClass = new CrabClass();
    public static CrabClass RBCCrabClass = new CrabClass();
    public static CrabClass PLCCrabClass = new CrabClass();

    // DEPRECATED, DON'T USE THESE! USE CRAB CLASSES INSTEAD
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
    public static int DCCFarthestCheckpoint;
    public static int DMCFarthestCheckpoint;
    public static int PCFarthestCheckpoint;
    public static int GLCFarthestCheckpoint;
    public static int PCCFarthestCheckpoint;
    public static int RBCFarthestCheckpoint;
    // END DEPRECATION

    // Start is called before the first frame update
    void Start()
    {
        allCrabClasses = new CrabClass[] {RCCrabClass, BCCrabClass, DCCCrabClass, DCCrabClass, DMCCrabClass, DRCCrabClass, FCCrabClass, GCCrabClass, GLCCrabClass, GCCCrabClass, PCCCrabClass, PCCrabClass, PHCCrabClass, PLCCrabClass, RBCCrabClass, RCCCrabClass, RKCCrabClass, SCCrabClass, SDCCrabClass, SPCCrabClass };
        LoadProgressData();
        // Set up all crab classes
        BCCrabClass.name = "BC";
        RCCrabClass.name = "RC";
        RCCCrabClass.name = "RCC";
        DCCCrabClass.name = "DCC";
        DCCrabClass.name = "DC";
        DMCCrabClass.name = "DMC";
        DRCCrabClass.name = "DRC";
        FCCrabClass.name = "FC";
        GCCrabClass.name = "GC";
        GLCCrabClass.name = "GLC";
        GCCCrabClass.name = "GCC";
        PCCCrabClass.name = "PCC";
        PCCrabClass.name = "PC";
        PHCCrabClass.name = "PHC";
        PLCCrabClass.name = "PLC";
        RBCCrabClass.name = "RBC";
        RKCCrabClass.name = "RKC";
        SCCrabClass.name = "SC";
        SDCCrabClass.name = "SDC";
        SPCCrabClass.name = "SPC";
        foreach (CrabClass crab in allCrabClasses)
        {
            crab.winsStatName = crab.name + "_wins";
            if (crab.winsStatName == "DCC_wins")
            {
                crab.maximumFarthestCheckpoint = 3;
            }
            else if (crab.winsStatName == "PCC_wins")
            {
                crab.maximumFarthestCheckpoint = 5;
            }
            else if (crab.winsStatName == "PC_wins")
            {
                crab.maximumFarthestCheckpoint = 32;
            }
            else if (crab.winsStatName == "PHC_wins")
            {
                crab.maximumFarthestCheckpoint = 35;
            }
            else if (crab.winsStatName == "RCC_wins" || crab.winsStatName == "GCC_wins" || crab.winsStatName == "DMC_wins")
            {
                crab.maximumFarthestCheckpoint = 0;
            }
            else 
            {
                crab.maximumFarthestCheckpoint = 31;
            }
        }
        // end crab class setup

        if (IsMainInstance) maininstance = this;
        controls = new Controls();
        controls.Enable();
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
        GlassCrabUnlocked = true;
        PollutionCrabUnlocked = true;
        DementiaCrabUnlocked = true;
        foreach (CrabClass crab in allCrabClasses)
        {
            crab.farthestCheckpoint = crab.maximumFarthestCheckpoint;
        }
        SaveProgressData();
    }

    public void Reset(bool OverrideDeTermination = false)
    {
        if (DeTermination && !OverrideDeTermination)
        {
            if (HasDefiedDeath == 0)
            {
                HasDefiedDeath = 1;
                SteamUserStats.SetStat("Has_Defied_Death", HasDefiedDeath);
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
        data.GIGABossStage = GIGABossStage;
        data.GlassCrabUnlocked = GlassCrabUnlocked;
        data.PollutionCrabUnlocked = PollutionCrabUnlocked;
        data.RCCrabClass = RCCrabClass;
        data.RCCCrabClass = RCCCrabClass;
        data.DCCrabClass = DCCrabClass;
        data.DRCCrabClass = DRCCrabClass;
        data.BCCrabClass = BCCrabClass;
        data.SCCrabClass = SCCrabClass;
        data.FCCrabClass = FCCrabClass;
        data.GCCrabClass = GCCrabClass;
        data.GCCCrabClass = GCCCrabClass;
        data.PHCCrabClass = PHCCrabClass;
        data.SPCCrabClass = SPCCrabClass;
        data.RKCCrabClass = RKCCrabClass;
        data.SDCCrabClass = SDCCrabClass;
        data.DCCCrabClass = DCCCrabClass;
        data.DMCCrabClass = DMCCrabClass;
        data.PCCrabClass = PCCrabClass;
        data.GLCCrabClass = GLCCrabClass;
        data.PCCCrabClass = PCCCrabClass;
        data.RBCCrabClass = RBCCrabClass;
        data.PLCCrabClass = PLCCrabClass;
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
            if (data.RCCrabClass != null) RCCrabClass = data.RCCrabClass;
            if (data.RCCCrabClass != null) RCCCrabClass = data.RCCCrabClass;
            if (data.DCCrabClass != null) DCCrabClass = data.DCCrabClass;
            if (data.DRCCrabClass != null) DRCCrabClass = data.DRCCrabClass;
            if (data.BCCrabClass != null) BCCrabClass = data.BCCrabClass;
            if (data.SCCrabClass != null) SCCrabClass = data.SCCrabClass;
            if (data.FCCrabClass != null) FCCrabClass = data.FCCrabClass;
            if (data.GCCrabClass != null) GCCrabClass = data.GCCrabClass;
            if (data.GCCCrabClass != null) GCCCrabClass = data.GCCCrabClass;
            if (data.PHCCrabClass != null) PHCCrabClass = data.PHCCrabClass;
            if (data.SPCCrabClass != null) SPCCrabClass = data.SPCCrabClass;
            if (data.RKCCrabClass != null) RKCCrabClass = data.RKCCrabClass;
            if (data.SDCCrabClass != null) SDCCrabClass = data.SDCCrabClass;
            if (data.DCCCrabClass != null) DCCCrabClass = data.DCCCrabClass;
            if (data.DMCCrabClass != null) DMCCrabClass = data.DMCCrabClass;
            if (data.PCCrabClass != null) PCCrabClass = data.PCCrabClass;
            if (data.GLCCrabClass != null) GLCCrabClass = data.GLCCrabClass;
            if (data.PCCCrabClass != null) PCCCrabClass = data.PCCCrabClass;
            if (data.RBCCrabClass != null) RBCCrabClass = data.RBCCrabClass;
            if (data.PLCCrabClass != null) PLCCrabClass = data.PLCCrabClass;
            // DEPRECATED, DON'T USE THESE! USE CRAB CLASSES INSTEAD
            RCCrabClass.legacyFarthestCheckpoint = data.RCFarthestCheckpoint;
            BCCrabClass.legacyFarthestCheckpoint = data.BCFarthestCheckpoint;
            DCCrabClass.legacyFarthestCheckpoint = data.DCFarthestCheckpoint;
            DRCCrabClass.legacyFarthestCheckpoint = data.DRCFarthestCheckpoint;
            FCCrabClass.legacyFarthestCheckpoint = data.FCFarthestCheckpoint;
            GCCrabClass.legacyFarthestCheckpoint = data.GCFarthestCheckpoint;
            PHCCrabClass.legacyFarthestCheckpoint = data.PHCFarthestCheckpoint;
            SCCrabClass.legacyFarthestCheckpoint = data.SCFarthestCheckpoint;
            SPCCrabClass.legacyFarthestCheckpoint = data.SPCFarthestCheckpoint;
            RKCCrabClass.legacyFarthestCheckpoint = data.RKCFarthestCheckpoint;
            SDCCrabClass.legacyFarthestCheckpoint = data.SDCFarthestCheckpoint;
            DMCCrabClass.legacyFarthestCheckpoint = data.DMCFarthestCheckpoint;
            DCCCrabClass.legacyFarthestCheckpoint = data.DCCFarthestCheckpoint;
            PCCrabClass.legacyFarthestCheckpoint = data.PCFarthestCheckpoint;
            GLCCrabClass.legacyFarthestCheckpoint = data.GLCFarthestCheckpoint;
            PCCCrabClass.legacyFarthestCheckpoint = data.PCCFarthestCheckpoint;
            RBCCrabClass.legacyFarthestCheckpoint= data.RBCFarthestCheckpoint;
            foreach (CrabClass crab in allCrabClasses)
            {
                if (crab.legacyFarthestCheckpoint > crab.farthestCheckpoint) crab.farthestCheckpoint = crab.legacyFarthestCheckpoint;    
            }
            // end deprecation
            GIGABossStage = data.GIGABossStage;
            GlassCrabUnlocked = data.GlassCrabUnlocked;
            PollutionCrabUnlocked = data.PollutionCrabUnlocked;
            allCrabClasses = new CrabClass[] {RCCrabClass, BCCrabClass, DCCCrabClass, DCCrabClass, DMCCrabClass, DRCCrabClass, FCCrabClass, GCCrabClass, GLCCrabClass, GCCCrabClass, PCCCrabClass, PCCrabClass, PHCCrabClass, PLCCrabClass, RBCCrabClass, RCCCrabClass, RKCCrabClass, SCCrabClass, SDCCrabClass, SPCCrabClass };
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
        PollutionCrabUnlocked = false;
        DementiaCrabUnlocked = false;
        // DEPRECATED, DON'T USE THESE! USE CRAB CLASSES INSTEAD
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
        DCCFarthestCheckpoint = 0;
        PCFarthestCheckpoint = 0;
        GLCFarthestCheckpoint = 0;
        PCCFarthestCheckpoint = 0;
        RBCFarthestCheckpoint = 0;
        //end deprecation
        foreach (CrabClass crab in allCrabClasses)
        {
            crab.farthestCheckpoint = 0;
        }
        GlassCrabUnlocked = false;
        BossStage = 0;
        GIGABossStage = 0;
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

    public static void SetUnlockGLC(bool value)
    {
        GlassCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetUnlockPLC(bool value)
    {
        PollutionCrabUnlocked = value;
        SaveProgressData();
    }

    public static void SetBossStage(int value)
    {
        BossStage = value;
        SaveProgressData();
    }

    public static void SetCrabFarthestCheckpoint(CrabClass crab, int value)
    {
        crab.setFarthestCheckpoint(value);
    }

    public void ResetCrabFarthestCheckpoint(string crabName)
    {
        CrabClass crab = null;
        foreach (CrabClass crab2 in allCrabClasses)
        {
            if (crab2.name == crabName)
            {
                crab = crab2;
                break;
            }
        }
        crab.setFarthestCheckpoint(0);
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
    public bool PollutionCrabUnlocked;
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
    public int DCCFarthestCheckpoint;
    public int PCFarthestCheckpoint;
    public int GLCFarthestCheckpoint;
    public int PCCFarthestCheckpoint;
    public int RBCFarthestCheckpoint;
    public CrabClass RCCrabClass;
    public CrabClass RCCCrabClass;
    public CrabClass DCCrabClass;
    public CrabClass DRCCrabClass;
    public CrabClass BCCrabClass;
    public CrabClass SCCrabClass;
    public CrabClass FCCrabClass;
    public CrabClass GCCrabClass;
    public CrabClass GCCCrabClass;
    public CrabClass PHCCrabClass;
    public CrabClass SPCCrabClass;
    public CrabClass RKCCrabClass;
    public CrabClass SDCCrabClass;
    public CrabClass DCCCrabClass;
    public CrabClass DMCCrabClass;
    public CrabClass PCCrabClass;
    public CrabClass GLCCrabClass;
    public CrabClass PCCCrabClass;
    public CrabClass RBCCrabClass;
    public CrabClass PLCCrabClass;
    public string SceneToLoad;
    public int BossStage;
    public int GIGABossStage;
    public bool GlassCrabUnlocked;
}
