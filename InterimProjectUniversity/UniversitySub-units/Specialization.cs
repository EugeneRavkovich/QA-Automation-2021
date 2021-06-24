using System;
using System.Collections.Generic;

namespace InterimProjectUniversity
{
    [Serializable]
    public class Specialization
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<int> CourseId { get; set; }
        public List<Course> Courses;


        public Specialization() {}


        public Specialization(string name, int id , List<int> courseId,
            List<Course> courses)
        {
            this.Name = name;
            this.Id = Id;
            this.CourseId = courseId;
            this.Courses = courses;
        }
    }
}
