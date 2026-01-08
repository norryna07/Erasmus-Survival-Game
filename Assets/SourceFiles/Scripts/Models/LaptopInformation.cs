using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class LaptopInformation
    {
        public bool CVDone = false;
        public bool OLADone = false;
        public bool transportDone = false;
        public bool accommodationDone = false;
        public string accommodationName;
    }
}