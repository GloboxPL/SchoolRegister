using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Lesson
    {
        public int Id { get; protected set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Group Group { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public int Day { get; set; }
        public int Time { get; set; }
        public IList<Mark> Marks { get; set; } = new List<Mark>();

        public Lesson() { }
    }
}