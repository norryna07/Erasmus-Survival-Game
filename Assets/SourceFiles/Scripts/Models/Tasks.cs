using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class Task
    {
        public string taskCategory;
        public string description;
        public string interaction;
        public int minHour, maxHour;
        public int day = -300;
        public int health, happiness, money, uniPoints;
    }

    [System.Serializable]
    public class TasksJSON
    {
        public Task[] dailyTasks;
        public Task[] additionalTasks;
    }

    [System.Serializable]
    public class ToDoTask
    {
        public Task task;
        public bool done;
        public bool available;
    }

    [System.Serializable]
    public class ToDoList
    {
        public List<ToDoTask> list = new List<ToDoTask>();
        public int day;
    }
}