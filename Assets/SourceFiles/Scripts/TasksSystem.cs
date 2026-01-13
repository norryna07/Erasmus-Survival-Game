using UnityEngine;
using ErasmusGame.Models;
using System.IO;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class TasksSystem : MonoBehaviour
{
    public static TasksSystem Instance { get; private set; }

    public bool IsInitialized { get; private set; }
    private ToDoList toDoList;
    private TasksJSON tasks;

    public Color rightColor = Color.darkGreen;
    public Color wrongColor = Color.red;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        // Wait until GameStatus is ready
        yield return new WaitUntil(() => GameStatus.Instance != null 
                                    && GameStatus.Instance.IsInitialized);

        LoadData();
        IsInitialized = true;
        GameStatus.Instance.OnDayChanged += EndOfDay;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInitialized) return;
        UpdateList();
    }

    public void SaveData()
    {
        if (toDoList == null) return;

        string json = JsonUtility.ToJson(toDoList, true);

        string path = Path.Combine(
            Application.persistentDataPath,
            "ToDoList.json"
        );

        File.WriteAllText(path, json);

        Debug.Log("ToDo list save to: " + path);
    }

    public void LoadData()
    {
        // read the tasks json from resources
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/tasks");
        if (jsonFile == null)
        {
            Debug.LogError("JSON file not found!");
            return;
        }

        string json = jsonFile.text;
        tasks = JsonUtility.FromJson<TasksJSON>(json);
        Debug.Log(tasks.additionalTasks[0].day);

        string path = Path.Combine(
            Application.persistentDataPath,
            "ToDoList.json"
        );

        if (!File.Exists(path))
        {
            MakeList();
        } else
        {
            json = File.ReadAllText(path);
            toDoList = JsonUtility.FromJson<ToDoList>(json);
            if (toDoList.day != GameStatus.Instance.day)
            {
                MakeList();
            }
        }
    }

    void MakeList()
    {
        // Debug.Log(GameStatus.Instance.day);
        toDoList = new ToDoList();
        // add the daily tasks
        foreach (var task in tasks.dailyTasks)
        {
            toDoList.list.Add(new ToDoTask
            {
                task = task,
                done = false,
                available = false
            });
        }

        foreach (var task in tasks.additionalTasks)
        {
            if (task.day == GameStatus.Instance.day)
            {
                toDoList.list.Add(new ToDoTask
                {
                    task = task,
                    done = false,
                    available = false
                });
            }
        }
        toDoList.day = GameStatus.Instance.day;
        Debug.Log(toDoList.list.Count + " " + toDoList.list[toDoList.list.Count - 1].task.description);
    }

    void EvaluateList()
    {
        foreach (var task in toDoList.list)
        {
            if (task.done)
            {
                GameStatus.Instance.currentHealth += task.task.health;
                GameStatus.Instance.currentHappiness += task.task.happiness;
                GameStatus.Instance.currentMoney += task.task.money;
                GameStatus.Instance.currentUniPoints += task.task.uniPoints;
            } else
            {
                GameStatus.Instance.currentHealth -= task.task.health;
                GameStatus.Instance.currentHappiness -= task.task.happiness;
                GameStatus.Instance.currentMoney -= task.task.money;
                GameStatus.Instance.currentUniPoints -= task.task.uniPoints;
            }
        }
    }

    void EndOfDay()
    {
        EvaluateList();
        MakeList();
        Debug.Log("day change");
    }

    void UpdateList()
    {
        foreach(var task in toDoList.list)
        {
            task.available = GameStatus.Instance.hour >= task.task.minHour && GameStatus.Instance.hour <= task.task.maxHour;
        }
    }

    public void UpdateTasks(string interaction)
    {
        foreach (var task in toDoList.list)
        {
            if (task.task.interaction.Equals(interaction) && task.available)
            {
                task.done = true;
            }
        }
    }

    public List<ToDoTask> GetTasks()
    {
        return toDoList.list;
    }

    public bool IsTaskAvailable(int id)
    {
        return toDoList.list[id].available;
    }

    public bool IsTaskDone(int id)
    {
        return toDoList.list[id].done;
    }

    public int GetDay()
    {
        return toDoList.day;
    }
}
