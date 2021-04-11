namespace SchoolRegister.Models
{
    public class Mark
    {
        public int Id { get; protected set; }
        public Grades Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lesson Lesson { get; set; }
    }

    public enum Grades
    {
        A,
        MinusA,
        B,
        MinusB,
        C
    }
}