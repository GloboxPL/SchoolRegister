using System.Collections.Generic;
using System.Linq;
using SchoolRegister.Database;
using SchoolRegister.Models;
using SchoolRegister.Models.Dto;

namespace SchoolRegister.Services
{
    public class LessonsManagment
    {
        private readonly MainDbRepository _repo;

        public LessonsManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public IEnumerable<Lesson> GetTeacherLessons(int id)
        {
            var lessons = _repo.ReadLessonsByTeacher(id);
            return lessons;
        }

        public IEnumerable<Lesson> GetStudentLessons(int id)
        {
            var lessons = _repo.ReadLessonsByStudent(id);
            return lessons;
        }

        public IEnumerable<UserMinDto> GetStudentsByClass(string name)
        {
            var students = _repo.ReadStudentsByClass(name);
            return students.Select(x => new UserMinDto(x));
        }

        public void CheckFrequency(int id, int[] ids)
        {
            var lessons = _repo.ReadLesson(id);
            foreach (var studentId in ids)
            {
                var student = _repo.ReadStudent(id);
                var attendance = new Attendance(lessons, student);
                _repo.CreateAttendance(attendance);
            }
            _repo.SaveChanges();
        }
    }
}