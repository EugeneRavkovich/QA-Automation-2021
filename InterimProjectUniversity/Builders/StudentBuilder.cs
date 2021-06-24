using System.Collections.Generic;

namespace InterimProjectUniversity
{
    static class StudentBuilder
    {
        public static List<Student> Create(string studentsPath, List<Specialization> specs)
        {
            var students = Builder<Student>.Create(studentsPath);
            foreach (var student in students)
            {
                foreach (var spec in specs) 
                {
                    if (student.SpecializationId.Contains(spec.Id)) 
                    {
                        student.Specializations.Add(spec);
                    }
                }
            }
            return students;
        }
    }
}
