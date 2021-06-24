using System.Collections.Generic;
using System.Linq;

namespace InterimProjectUniversity
{
    class University
    {
        public List<Faculty> faculties;
        readonly string coursesPath = "../../../XMLfiles/Courses.xml";
        readonly string specializationsPath = "../../../XMLfiles/Specializations.xml";
        readonly string teachersPath = "../../../XMLfiles/Teachers.xml";
        readonly string studentsPath = "../../../XMLfiles/Students.xml";
        readonly string facultiesPath = "../../../XMLfiles/Faculties.xml";


        public University() 
        {
            var courses = Builder<Course>.Create(coursesPath);
            var specializations = SpecializationBuilder.Create(specializationsPath, courses);
            var teachers = TeacherBuilder.Create(teachersPath, courses);
            var students = StudentBuilder.Create(studentsPath, specializations);
            this.faculties = FacultyBuilder.Create(facultiesPath, specializations, teachers, students);
        }


        public object ProfessorsWhoTeachesMoreThanOneCourse()
        {
            var result = from faculty in faculties
                         from teacher in faculty.Teachers
                         where teacher.CourseId.Count() > 1 && teacher.Rank == "Professor"
                         select teacher;
            return result.ToList();
        }


        public object StudentsInTheSpecialty(string studentName) 
        {
            var result = from faculty in faculties
                         from student in faculty.Students
                         from spec in student.Specializations
                         where spec.Name == studentName
                         select student;
            return result.ToList();
        }


        public object StudentsAttendingTheCourse(string courseName) 
        {
            var result = from faculty in faculties
                         from student in faculty.Students
                         from spec in student.Specializations
                         from course in spec.Courses
                         where course.Name == courseName
                         select student;
            return result.ToList();
        }


        //public object CoursesTaughtInMoreThanOneFacultySpecialty(string facultyName) 
        //{
        //    var result = from faculty in faculties
        //                 where faculty.Name == facultyName
        //                 from spec in faculty


        //}


        public object AmmountOfProfessorsAndDocents() 
        {
            var result = from faculty in faculties
                         from teacher in faculty.Teachers
                         where teacher.Rank == "Professor" || teacher.Rank == "Docent"
                         select teacher;
            return result.Distinct().ToList();
        }


        public object CourseList() 
        {
            var result = from faculty in faculties
                         from spec in faculty.Specializations
                         from course in spec.Courses
                         select course;
            return result.Distinct().ToList();
        }


        //public object NumOfEmployee() 
        //{
        //    //have no sense yet
        //}
    } 
}
