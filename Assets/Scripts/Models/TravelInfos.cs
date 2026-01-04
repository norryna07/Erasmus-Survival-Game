using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class TravelInfo
    {
        public string originCountry;
        public string erasmusCountry;
        public string method;
        public int price;
        public double timeHours;
    }

    [System.Serializable]
    public class TravelInfosJSON
    {
        public TravelInfo[] travelInfos;
    }
}