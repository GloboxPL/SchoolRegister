namespace SchoolRegister.Models
{
    public class Attendance
    {
        public int Id { get; protected set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
        public bool IsPresent { get; set; }

        public Attendance() { }

        public Attendance(Lesson lesson, Student student, bool isPresent = true)
        {
            Lesson = lesson;
            Student = student;
            IsPresent = isPresent;
        }
    }
}