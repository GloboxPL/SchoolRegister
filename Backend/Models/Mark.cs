namespace SchoolRegister.Models
{
    public class Mark
    {
        public int Id { get; protected set; }
        public int Value { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }

        public Mark() { }

        public Mark(int value, Student student, Lesson lesson)
        {
            Value = value;
            Student = student;
            Lesson = lesson;
        }
    }
}