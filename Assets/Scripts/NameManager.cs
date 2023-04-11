using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string Name = "";
    public BestScore bestScore;

    string jsonPath;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        jsonPath = Application.persistentDataPath + "/bestScore.json";
        bestScore = LoadScore();

        
        DontDestroyOnLoad(gameObject);

    }

    [Serializable]
    public class BestScore
    {
        public string Name;
        public int Score;
        public BestScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public void SaveScore()
    {
        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(jsonPath, json);
    }

    public BestScore LoadScore()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<BestScore>(json);
        }
        return new BestScore(Name, 0);
    }

}
