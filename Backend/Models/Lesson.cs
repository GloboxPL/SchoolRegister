using System;

namespace SchoolRegister.Models
{
    public class Lesson
    {
        public int Id { get; protected set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Group Group { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Notes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Lesson() { }
    }

    public class LessonIn{
        public int TeacherId { get; set; }
        public string GroupName { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public string Notes { get; set; }
        public string StartTime { get; set; }
    }
}