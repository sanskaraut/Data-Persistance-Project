using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayerName;
    public int currentPlayerScore;
    public string bestPlayerName;
    public int bestPlayerScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // SaveBestPlayerName();
        // SaveBestPlayerScore();
        // LoadBestPlayerName();
        // LoadBestPlayerScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReadPlayerNameInput(string input)
    {
        currentPlayerName = input;
        Debug.Log(currentPlayerName);
        // SaveBestPlayerName();
    }
        public void SaveBestPlayerData1()
    {
        SaveBestPlayerData data = new SaveBestPlayerData();
        data.bestPlayerNameInJson = currentPlayerName;
        data.bestPlayerScoreInJson = currentPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestPlayerData1()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveBestPlayerData data = JsonUtility.FromJson<SaveBestPlayerData>(json);

            bestPlayerName = data.bestPlayerNameInJson;
            bestPlayerScore = data.bestPlayerScoreInJson;
        }
    }
    [System.Serializable]
    public class SaveBestPlayerData
    {
        public string bestPlayerNameInJson;
        public int bestPlayerScoreInJson;
    }
}
