using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager instance;
    public static string actualName = "Nadie";
    public static string recordName = "Nadie";
    public static int record = 0;
    public static string actualRecord;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRecord();       
    }

    [System.Serializable]
    class SaveData
    {
        public string playerRecord;
        public int recordSaved;
    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.playerRecord = actualName;
        data.recordSaved = record;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            recordName = data.playerRecord;
            record = data.recordSaved;
            actualRecord = "Record: " + recordName + " = " + record;
        }
    }
}
