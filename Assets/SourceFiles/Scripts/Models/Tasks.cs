using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable] 
    public class DailyTask
    {
        public string taskCategory;
        public string description;
        public string interaction;
        public int minHour, maxHour;
        public int health, happiness, money, uniPoints;
    }

    [System.Serializable]
    public class AdditionalTask
    {
        public string taskCategory;
        public string description;
        public string interaction;
        public int minHour, maxHour;
        public int day;
        public int health, happiness, money, uniPoints;
    }

    [System.Serializable]
    public class TasksJSON
    {
        public DailyTask[] dailyTasks;
        public AdditionalTask[] additionalTasks;
    }
}