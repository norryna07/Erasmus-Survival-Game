using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class LuggageItem
    {
        public string name;
        public double weight;
    }

    [System.Serializable]
    public class LuggageJSON
    {
        public LuggageItem[] items;
    }
}