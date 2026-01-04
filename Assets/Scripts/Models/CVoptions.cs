using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class Option
    {
        public string text;
        public int score;
        public string[] major;
    }

    [System.Serializable]
    public class CVSection
    {
        public string name;
        public Option[] options;
    }

    [System.Serializable]
    public class CVoptionsJSON
    {
        public CVSection[] CVoptions;
    }
}