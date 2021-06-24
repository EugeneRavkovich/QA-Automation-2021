using System;
namespace InterimProjectUniversity
{
    [Serializable]
    public class Course
    {
        public string Name { get; set; }
        public int Id { get; set; }


        public Course() { }


        public Course(string name, int id) 
        {
            this.Name = name;
            this.Id = id;
        }   
    }
}
