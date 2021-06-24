namespace InterimProjectUniversity
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var university = new University();
            var cond1 = university.ProfessorsWhoTeachesMoreThanOneCourse();
            var cond2 = university.StudentsInTheSpecialty("NuclearPhysics");
            var cond3 = university.StudentsAttendingTheCourse("InformationTheory");
            var cond5 = university.AmmountOfProfessorsAndDocents();
            var cond6 = university.CourseList();
        }
    }

}
