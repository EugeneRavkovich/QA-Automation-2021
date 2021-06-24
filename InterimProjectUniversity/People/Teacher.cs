using System;
using System.Collections.Generic;

namespace InterimProjectUniversity
{
    [Serializable]
    public class Teacher : Person
    {
        public List<int> CourseId { get; set; }
        public string Rank { get; set; }
        public List<Course> TaughtCourses { get; set; }
        

        public Teacher() { }


        public Teacher(string name, string surname, int age, List<Course> taughtCoures) 
            :base(name, surname, age)
        {
            this.TaughtCourses = taughtCoures;
        }
    }
}
