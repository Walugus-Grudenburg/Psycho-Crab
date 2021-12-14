using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProgressHandler : MonoBehaviour
{
    public static Controls controls;
    public static Vector3 Checkpoint_Position;
    public bool IgnoreControls;
    public CrabLeg[] Legs;
    public LoadGame loader;
    public GameObject[] Moneys;
    public GameObject SignToRotate;
    public static string SceneToLoad;
    public static bool JumpUnlocked;
    public static bool Spookify;
    public static bool MoneyUnlocked;
    public static bool BatcrabUnlocked;
    public static bool GullcrabUnlocked;
    public static bool DizzycrabUnlocked;
    private static bool HasDataSaved;
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
            Reset();
        }
        if (MoneyUnlocked)
        {
            foreach (GameObject Money in Moneys)
            {
                Money.SetActive(true);
            }
            if (SignToRotate) SignToRotate.transform.Rotate(0, 0, 180);
        }
    }
    void Update()
    {
        if (controls.Crab.Reset.triggered && !IgnoreControls)
        {
            Reset();
        }
    }

    public void Reset()
    {
        gameObject.transform.position = Checkpoint_Position;
        foreach (CrabLeg leg in Legs)
        {
            if (leg.stickjoint)
            {
                leg.Unstick(null);
            }
        }
        
        if (SatanScript.HasChaseStarted)
        {
            loader.LoadLevel();
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
        data.DizzycrabUnlocked = DizzycrabUnlocked;
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
            DizzycrabUnlocked = data.DizzycrabUnlocked;
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
        DizzycrabUnlocked = value;
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
    public string SceneToLoad;
}
