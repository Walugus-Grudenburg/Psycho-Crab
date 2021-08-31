using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool Active;
    static float time;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        LoadTimerData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            time += Time.deltaTime;
            SaveTimerData();
            text.text = TimeSpan.FromSeconds(Mathf.Round(time * 10f) / 10f).ToString() + ".0";
        }
    }

    public static void SaveTimerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/TimerData.dat");
        TimerData data = new TimerData();
        data.time = time;
        formatter.Serialize(file, data);
        file.Close();
    }

    public static void LoadTimerData()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/TimerData.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/TimerData.dat", FileMode.Open);
            TimerData data = (TimerData)formatter.Deserialize(file);
            time = data.time;
            file.Close();
        }
        else
        {
            time = 0;
        }
    }

    public void ClearTimerData()
    {
        time = 0;
        SaveTimerData();
    }

    [Serializable]
    public class TimerData
    {
        public float time;
    }
}
