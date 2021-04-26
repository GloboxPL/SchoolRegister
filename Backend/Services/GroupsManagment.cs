using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolRegister.Database;
using SchoolRegister.Models;

namespace SchoolRegister.Services
{
    public class GroupsManagment
    {
        private readonly MainDbRepository _repo;

        public GroupsManagment(MainDbContext context)
        {
            _repo = new MainDbRepository(context);
        }

        public Group AddGroup(string name)
        {
            Group group = new Group(name);
            group = _repo.CreateGroup(group);
            _repo.SaveChanges();
            return group;
        }

        public Group AddStudentsToGroup(string name, int[] ids)
        {
            Group group = _repo.ReadGroup(name);
            List<Student> students = _repo.ReadStudents(ids).ToList();
            foreach (var student in students)
            {
                group.Students.Add(student);
            }
            _repo.UpdateGroup(group);
            _repo.SaveChanges();
            return group;
        }

        public Lesson AddLesson(LessonIn lessonIn)
        {
            DateTime time = DateTime.Parse(lessonIn.StartTime);
            Lesson lesson = new Lesson
            {
                Teacher = _repo.ReadUser(lessonIn.TeacherId) as Teacher,
                Group = _repo.ReadGroup(lessonIn.GroupName),
                Subject = lessonIn.Subject,
                Topic = lessonIn.Topic,
                Notes = lessonIn.Notes,
                StartTime = time,
                EndTime = time.AddMinutes(45)
            };
            _repo.CreateLesson(lesson);
            _repo.SaveChanges();
            return lesson;
        }
    }
}