using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{
    public Vector3 Checkpoint_Position;
    private bool HasDataSaved;
    // Start is called before the first frame update
    void Start()
    {
        LoadResetData();
        if (!HasDataSaved)
        {
            ResetCheckpointToDefault();
        }
        if (LoadGame.IsContinuing)
        {
            Reset();
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Reset Button"))
        {
            Reset();
        }
    }

    public void Reset()
    {
        gameObject.transform.position = Checkpoint_Position;
    }

    public void SaveResetData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/ResetData.dat");
        ResetData data = new ResetData();
        data.SavedCheckpointPositionX = Checkpoint_Position.x;
        data.SavedCheckpointPositionY = Checkpoint_Position.y;
        formatter.Serialize(file, data);
        file.Close();
    }

    public void LoadResetData()
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
            Checkpoint_Position = new Vector3 (data.SavedCheckpointPositionX,data.SavedCheckpointPositionY, 0);
            file.Close();
        }
        else
        {
            HasDataSaved = false;
        }
    }
    public void ResetCheckpointToDefault()
    {
        Checkpoint_Position = new Vector3(0, 5, 0);
    }
}

[Serializable]
public class ResetData
{
    public float SavedCheckpointPositionX;
    public float SavedCheckpointPositionY;
}
