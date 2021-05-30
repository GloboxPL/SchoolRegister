using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolRegister.Database;
using SchoolRegister.Models;

namespace SchoolRegister.Services
{
    public class LessonsManagment
    {
        private readonly MainDbRepository _repo;

        public LessonsManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public void CheckAttendance(Dictionary<int, AttendanceStatus> attandances, int lessonId)
        {
            Lesson lesson = _repo.ReadLesson(lessonId);
            var attandancesList = new List<Attendance>();
            var students = lesson.Group.Students;
            foreach (var item in attandances)
            {
                var student = students.Where(x => x.Id == item.Key).Single();
                var attandance = new Attendance(lesson, student, item.Value);
                attandancesList.Add(attandance);
            }
            _repo.CreateAttendance(attandancesList);
            _repo.SaveChanges();
        }

        public IEnumerable<Lesson> GetTeacherLessons(int id)
        {
            var lessons = _repo.ReadLessonsByTeacher(id);
            return lessons;
        }
    }
}