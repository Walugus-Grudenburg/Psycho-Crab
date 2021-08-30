using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class ProgressHandler : MonoBehaviour
{
    public static Vector3 Checkpoint_Position;
    public bool IgnoreControls;
    public static bool JumpUnlocked;
    public static bool Spookify;
    private static bool HasDataSaved;
    // Start is called before the first frame update
    void Start()
    {
        LoadProgressData();
        if (!HasDataSaved)
        {
            ResetProgressToDefault();
        }
        if (LoadGame.IsContinuing)
        {
            Reset();
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Reset Button") && !IgnoreControls)
        {
            Reset();
        }
    }

    public void Reset()
    {
        gameObject.transform.position = Checkpoint_Position;
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
            file.Close();
        }
        else
        {
            HasDataSaved = false;
        }
    }

    public static void ResetProgressToDefault()
    {
        Checkpoint_Position = new Vector3(0, 5, 0);
        JumpUnlocked = false;
    }

    public static void SetUnlockJumping(bool value)
    {
        JumpUnlocked = value;
        SaveProgressData();
    }

    public static void ToggleSpookify()
    {
        Spookify = !Spookify;
    }
}

[Serializable]
public class ResetData
{
    public float SavedCheckpointPositionX;
    public float SavedCheckpointPositionY;
    public bool JumpUnlocked;
}