using System;
using System.Collections.Generic;

namespace InterimProjectUniversity
{
    [Serializable]
    public class Faculty
    {
        public string Name { get; set; }
        public List<int> SpecializationId { get; set; }
        public int Id { get; set; }
        public List<Specialization> Specializations { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }


        public Faculty() { }


        public Faculty(string name, List<int> specId, int id, List<Specialization> specs,
            List<Student> students, List<Teacher> teachers)
        {
            this.Name = name;
            this.SpecializationId = specId;
            this.Id = id;
            this.Specializations = specs;
            this.Students = students;
            this.Teachers = teachers;
        }
    }
}
