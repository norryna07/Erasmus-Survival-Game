using UnityEngine;
using System.IO;
using ErasmusGame.Models;
using System;

public class GameStatus : MonoBehaviour
{
    public static GameStatus Instance { get; private set;}
    public bool IsInitialized { get; private set; }

    // ----- Time System ------
    public int day;
    public int hour;
    public int minute;
    public float realSecondsPerGameMinute = 0.5f;
    private float timer;
    public bool isPaused = false;
    public event Action OnDayChanged;

    
    // ---- Health -----
    public int maxHealth;
    public int minHealth;
    public int currentHealth;

    // ----- Money -----
    public int maxMoney;
    public int minMoney;
    public int currentMoney;

    // ---- Happiness ----
    public int maxHappiness;
    public int minHappiness;
    public int currentHappiness;

    // ---- University Points -----
    public int maxUniPoints;
    public int minUniPoints;
    public int currentUniPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        LoadData();
        IsInitialized = true;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isPaused) return;

        timer += Time.deltaTime;
        if (timer >= realSecondsPerGameMinute)
        {
            timer = 0f;
            AdvanceMinute();
        }
    }

    void AdvanceMinute()
    {
        minute++;

        if (minute >= 60)
        {
            minute = 0;
            hour++;
        }

        if (hour >= 24)
        {
            hour = 0;
            day++;
            OnDayChanged?.Invoke();
        }
    }

    public string GetTimeString()
    {
        return $"{hour:D2}:{minute:D2}";
    }


    void LoadData()
    {
        string path = Path.Combine(
            Application.persistentDataPath,
            "GameInformation.json"
        );
        GameInformation data;

        if (!File.Exists(path))
        {
            data = new GameInformation();
        } else
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<GameInformation>(json);
        }

        // ---- Apply values ----
        day = data.day;
        hour = data.hour;
        minute = data.minute;

        maxHealth = data.maxHealth;
        minHealth = data.minHealth;
        currentHealth = data.currentHealth;

        maxMoney = data.maxMoney;
        minMoney = data.minMoney;
        currentMoney = data.currentMoney;

        maxHappiness = data.maxHappiness;
        minHappiness = data.minHappiness;
        currentHappiness = data.currentHappiness;

        maxUniPoints = data.maxUniPoints;
        minUniPoints = data.minUniPoints;
        currentUniPoints = data.currentUniPoints;

        Debug.Log("GameStatus loaded successfully");
    }

    public void SaveData(string currentScene)
    {
        GameInformation gameInformation = new GameInformation
        {
            day = this.day,
            hour = this.hour,
            minute = this.minute,
            maxHappiness = this.maxHappiness,
            minHappiness = this.minHappiness,
            currentHappiness = this.currentHappiness,
            maxMoney = this.maxMoney,
            minMoney = this.minMoney,
            currentMoney = this.currentMoney,
            maxHealth = this.maxHealth,
            minHealth = this.minHealth,
            currentHealth = this.currentHealth,
            maxUniPoints = this.maxUniPoints,
            minUniPoints = this.minUniPoints,
            currentUniPoints = this.currentUniPoints,
            currentScene = "BeforeScene"
        };

        string json = JsonUtility.ToJson(gameInformation, true);

        string path = Path.Combine(
            Application.persistentDataPath,
            "GameInformation.json"
        );

        File.WriteAllText(path, json);

        Debug.Log("Game status save to: " + path);
    }
}
