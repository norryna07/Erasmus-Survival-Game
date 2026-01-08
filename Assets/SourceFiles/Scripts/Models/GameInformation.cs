using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class GameInformation
    {
        public int day = -10;
        public int maxHealth = 100;
        public int minHealth = 0;
        public int currentHealth = 100;
        public int maxHappiness = 1000;
        public int minHappiness = -1000;
        public int currentHappiness = 1000;
        public int maxMoney = 3500;
        public int minMoney = 0;
        public int currentMoney = 3500;
        public int maxUniPoints = 30;
        public int minUniPoints = 0;
        public int currentUniPoints = 0;
        public string currentScene;
    }
}