using System.Collections.Generic;

namespace InterimProjectUniversity
{
    static class TeacherBuilder
    {
        public static List<Teacher> Create(string path, List<Course> courses)
        {
            var teachers = Builder<Teacher>.Create(path);
            foreach (var teacher in teachers)
            {
                foreach (var course in courses)
                {
                    if (teacher.CourseId.Contains(course.Id))
                    {
                        teacher.TaughtCourses.Add(course);
                    }
                }
            }
            return teachers;
        }
    }
}
