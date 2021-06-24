using System;
using System.Collections.Generic;

namespace InterimProjectUniversity
{
    [Serializable]
    public class Student: Person
    {
        public List<Specialization> Specializations { get; set; }
        public List<int> SpecializationId { get; set; }


        public Student() { }


        public Student(string name, string surname, int age, List<Specialization> specializations)
            : base(name, surname, age) 
        {
            this.Specializations = specializations;
        }
    }
}
