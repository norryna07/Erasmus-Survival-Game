using UnityEngine;

namespace ErasmusGame.Models {
[System.Serializable]
public class PlayerProfile
{
    public string name { get; set; }
    public string surname { get; set; }
    public string gender { get; set; }
    public string homeCountry { get; set; }
    public string erasmusCountry { get; set; }
    public string major { get; set; }
}
}