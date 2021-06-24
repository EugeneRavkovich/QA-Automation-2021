using System.Collections.Generic;

namespace InterimProjectUniversity
{
    static class FacultyBuilder
    {
        public static List<Faculty> Create(string path, List<Specialization> specs, 
            List<Teacher> teachers, List<Student> students)
        {
            var faculties = Builder<Faculty>.Create(path);
            foreach (var faculty in faculties)
            {
                foreach (var spec in specs)
                {
                    if (faculty.SpecializationId.Contains(spec.Id))
                    {
                        faculty.Specializations.Add(spec);
                    }
                }

                foreach (var student in students)
                {
                    foreach (var id in student.SpecializationId)
                    {
                        if (faculty.SpecializationId.Contains(id)) 
                        {
                            faculty.Students.Add(student);
                        }
                    }
                }

                foreach (var spec in faculty.Specializations) 
                {
                    foreach (var teacher in teachers) 
                    {
                        foreach (var courseId in teacher.CourseId) 
                        {
                            if (spec.CourseId.Contains(courseId) &&
                                !faculty.Teachers.Contains(teacher)) 
                            {
                                faculty.Teachers.Add(teacher);
                                break;
                            }
                        }
                    }
                }
            }
            return faculties;
        }
    }
}
