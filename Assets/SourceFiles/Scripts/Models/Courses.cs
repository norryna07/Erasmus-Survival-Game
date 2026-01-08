using UnityEngine;

namespace ErasmusGame.Models
{
    [System.Serializable]
    public class Translation
    {
        public string Greece;
        public string Bulgaria;
        public string Armenia;
        public string Turkey;
        public string Spain;
        public string Italy;
        public string Austria;
        public string France;
        public string Portugal;
        public string Poland;
        public string Romania;

        public string GetByCountry(string country)
        {
            switch (country)
            {
                case "Greece": return Greece;
                case "Bulgaria": return Bulgaria;
                case "Armenia": return Armenia;
                case "Turkey": return Turkey;
                case "Spain": return Spain;
                case "Italy": return Italy;
                case "Austria": return Austria;
                case "France": return France;
                case "Portugal": return Portugal;
                case "Poland": return Poland;
                case "Romania": return Romania;
                default: return null;
            }
        }
    }

    [System.Serializable]
    public class Course
    {
        public string courses_id;
        public string englishName;
        public string major;
        public Translation translations;
    }

    [System.Serializable]
    public class CoursesJSON
    {
        public Course[] courses;
    }
}