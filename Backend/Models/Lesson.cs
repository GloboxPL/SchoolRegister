namespace SchoolRegister.Models
{
    public class Lesson
    {
        public int Id { get; protected set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public string Topic { get; set; }
        public string Notes { get; set; }

        public Lesson() { }
    }
}