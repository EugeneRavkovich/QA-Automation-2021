using System.Collections.Generic;


namespace InterimProjectUniversity
{
    static class SpecializationBuilder
    {
        public static List<Specialization> Create(string path, List<Course> courses)
        {
            var specializations = Builder<Specialization>.Create(path);
            foreach (var spec in specializations) 
            {
                foreach (var course in courses) 
                {
                    if (spec.CourseId.Contains(course.Id)) 
                    {
                        spec.Courses.Add(course);
                    }
                }
            }
            return specializations;
        }
    }
}
