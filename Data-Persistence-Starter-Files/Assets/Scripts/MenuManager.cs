using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public int bestScore;
    public string bestPlayerName;
    public string playerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }

    [Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveBestPlayed()
    {
        var data = new SaveData() {bestScore = bestScore, bestPlayerName = bestPlayerName};
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayed()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<SaveData>(json);
        bestScore = data.bestScore;
        bestPlayerName = data.bestPlayerName;
    }
}