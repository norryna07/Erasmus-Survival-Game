using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class GameInformation
    {
        public int day;
        public int maxHealth;
        public int minHealth;
        public int currentHealth;
        public int maxHappiness;
        public int minHappiness;
        public int currentHappiness;
        public int maxMoney;
        public int minMoney;
        public int currentMoney;
        public int maxUniPoints;
        public int minUniPoints;
        public int currentUniPoints;
        public string currentScene;
    }
}