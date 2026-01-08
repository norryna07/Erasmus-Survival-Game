using System.Security;
using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable] 
    public class Accommodation
    {
        public string name;
        public string type;
        public string space;
        public bool privateKitchen ;
        public int roommates;
        public int distanceToUni;
        public int distanceToCenter;
        public bool privateBathroom;
        public int price;
        public string warning;
    }

    [System.Serializable]
    public class PriceDifference
    {
        public string name;
        public double multiplicationFactor;
    }

    [System.Serializable]
    public class AccommodationsJSON
    {
        public Accommodation[] accommodations;
        public PriceDifference[] priceDifferences;
    }

}

