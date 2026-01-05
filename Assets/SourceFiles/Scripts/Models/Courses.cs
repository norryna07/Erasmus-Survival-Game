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
    }

    [System.Serializable]
    public class Course
    {
        public string courses_id;
        public string englishName;
        public string major;
        public Translation translation;
    }

    [System.Serializable]
    public class CoursesJSON
    {
        public Course[] courses;
    }
}