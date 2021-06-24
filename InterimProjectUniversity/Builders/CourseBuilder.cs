using System;
using System.Xml.Linq;
using System.Linq;

namespace InterimProjectUniversity
{
    static class CourseBuilder
    {
        public static object Create(string path, int courseId)
        {
            XDocument xdoc = XDocument.Load(path);
            var items = from xe in xdoc.Element("ArrayOfCourse").Elements("Course")
                        where xe.Element("Id").Value == courseId.ToString()
                        select new Course
                        {
                            Name = xe.Element("Name").Value,
                            Id = Convert.ToInt32(xe.Element("Id").Value)
                        };
            return items.ToList();
        }
    }
}
