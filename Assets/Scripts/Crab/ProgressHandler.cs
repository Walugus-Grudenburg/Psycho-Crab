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
    private static bool HasDataSaved;
    static int HasDefiedDeath;
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
    }

    private void LateUpdate()
    {
        if (ResetLate)
        {
            ResetLate = false;
            Reset(true);
        }
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
        data.BossStage = BossStage;
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
            BossStage = data.BossStage;
            file.Close();
        }
        else
        {
            HasDataSaved = false;
        }
    }

    public static void ResetProgressToDefault()
    {
        ResetCheckpointData();
        JumpUnlocked = false;
        BatcrabUnlocked = false;
        GullcrabUnlocked = false;
        DizzyCrabUnlocked = false;
        GullcrabUnlocked = false;
        SantaCrabUnlocked = false;
        PrehistoricCrabUnlocked = false;
        BossStage = 0;
        SceneToLoad = "World 1";
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

    public static void SetBossStage(int value)
    {
        BossStage = value;
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
    public string SceneToLoad;
    public int BossStage;
}
