namespace Backend.Models.Dto
{
    public class NewLessonDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public string ClassName { get; set; }
        public int Day { get; set; }
        public int Lesson { get; set; }
    }
}