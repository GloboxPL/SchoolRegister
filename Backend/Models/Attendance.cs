using System.Collections.Generic;

namespace SchoolRegister.Models
{
    public class Attendance
    {
        public int Id { get; protected set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Student Students { get; set; }
        public AttendanceStatus Status { get; set; }

        public Attendance() { }

        public Attendance(Lesson lesson, Student students, AttendanceStatus status)
        {
            Lesson = lesson;
            Students = students;
            Status = status;
        }
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late
    }
}