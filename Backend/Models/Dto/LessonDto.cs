using SchoolRegister.Models;

namespace Backend.Models.Dto
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Subject { get; set; }
        public string Topic { get; set; }
        public int Day { get; set; }
        public int Time { get; set; }

        public LessonDto(Lesson lesson)
        {
            Id = lesson.Id;
            ClassName = lesson.Group.Name;
            Subject = lesson.Subject;
            Topic = lesson.Topic;
            Day = lesson.Day;
            Time = lesson.Time;
        }
    }
}